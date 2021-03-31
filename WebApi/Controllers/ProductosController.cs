using CoreData.Entities;
using CoreData.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductosController : ControllerBase
    {
        private readonly IProductoRepository _producto;

        public ProductosController(IProductoRepository producto)
        {
            this._producto = producto;
        }

        [HttpGet]
        public async Task<ActionResult<List<Producto>>> GetProductos()
        {
            var Productos =  await this._producto.GetListProductosAsync();

            return Ok(Productos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Producto>> GetProducto(int id)
        {
            return await this._producto.GetProductoByIdAsync(id);
           
        }
    }
}
