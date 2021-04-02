using AutoMapper;
using CoreData.Entities;
using CoreData.Interfaces;
using CoreData.Specification;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Schema;
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


        //http://localhost:27768/api/Productos/
        [HttpGet]
        //string sort, int? marca, int? categoria
        //Task<ActionResult<List<Producto>>>
        public async Task<ActionResult<Pagination<ProductoDto>>>
            GetProductos([FromQuery]ProductoSpecParams productoParams)//FromQuery para especificar que los parámetros provienen de la URL
        {
            //sort, marca, categoria
            var spec = new ProductoRelationships(productoParams);

            var productos =  await this._producto.GetAllWithSpec(spec);

            var specCount = new ProductoForCountSpecs(productoParams);

            var totalProductos = await this._producto.CountAsync(specCount);

            var rounded = Math.Ceiling(Convert.ToDecimal(totalProductos / productoParams.PageSize));//Aproximar al maximo el decimal

            var totalPages = Convert.ToInt32(rounded);

            var data = this._mapper.Map<IReadOnlyList<Producto>, IReadOnlyList<ProductoDto>>(productos);

            if (productos == null)
            {
                return NotFound(new CodeErrorResponse(404));
            }

            return Ok(
                new Pagination<ProductoDto>
                {
                    Count = totalProductos,
                    Data = data,
                    PageCount = totalPages,
                    PageIndex = productoParams.PageIndex,
                    PageSize = productoParams.PageSize
                }
             );

            //return Ok(this._mapper.Map<IReadOnlyList<Producto>, 
            //    IReadOnlyList<ProductoDto>>(productos));//Ok cuando es una lista IReadOnlyList
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
