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

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IGenericRepository<Producto> _producto;
        private readonly IMapper _mapper;

        public ProductosController(IGenericRepository<Producto> producto, IMapper mapper)
        {
            this._producto = producto;
            this._mapper = mapper;
        }


        //http://localhost:27768/Productos
        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var spec = new ProductoRelationships();

            var productos =  await this._producto.GetAllWithSpec(spec);

            return Ok(this._mapper.Map<IReadOnlyList<Producto>, 
                IReadOnlyList<ProductoDto>>(productos));//Ok cuando es una lista IReadOnlyList
        }

        //http://localhost:27768/Productos/1
        [HttpGet("{id}")]
        public async Task<ActionResult<ProductoDto>> GetProducto(int id)
        {
            //spec = Debe incluir la lógica entre las entidades y la lógica de la condición.
            var spec = new ProductoRelationships(id);//Si no se le pasa parámetro solo crea las relaciones

            //return await this._producto.GetByIdWithSpec(spec);           
            var producto = await this._producto.GetByIdWithSpec(spec);

            return this._mapper.Map<Producto, ProductoDto>(producto);
        }
    }
}
