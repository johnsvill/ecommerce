using AutoMapper;
using CoreData.Entities;
using CoreData.Interfaces;
using CoreData.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.DTOs;
using WebApi.Errors;

namespace WebApi.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    public class ProductosController : BaseApiController
    {
        private readonly IGenericRepository<Producto> _producto;
        private readonly IMapper _mapper;

        public ProductosController(IGenericRepository<Producto> producto, IMapper mapper)
        {
            this._producto = producto;
            this._mapper = mapper;
        }


        //http://localhost:27768/api/Productos/1000
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoRelationships();

            var productos =  await this._producto.GetAllWithSpec(spec);

            if (productos == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            return Ok(this._mapper.Map<IReadOnlyList<Producto>, 
                IReadOnlyList<ProductoDto>>(productos));//Ok cuando es una lista IReadOnlyList
        }

        //http://localhost:27768/api/Productos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            //spec = Debe incluir la lógica entre las entidades y la lógica de la condición.
            var spec = new ProductoRelationships(id);//Si no se le pasa parámetro solo crea las relaciones

            //return await this._producto.GetByIdWithSpec(spec);           
            var producto = await this._producto.GetByIdWithSpec(spec);

            if(producto == null)
            {
                return NotFound(new CodeErrorResponse(404, "El producto no existe"));
            }

            return this._mapper.Map<Producto, ProductoDto>(producto);
        }
    }
}
