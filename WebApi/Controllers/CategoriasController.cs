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
    public class CategoriasController : ControllerBase
    {
        private readonly IGenericRepository<Categoria> _categoria;

        public CategoriasController(IGenericRepository<Categoria> categoria)
        {
            this._categoria = categoria;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Categoria>>> GetCategoriasAll()
        {
            return Ok(await this._categoria.GetListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Categoria>> GetCategoriaById(int id)
        {
            return await this._categoria.GetByIdAsync(id);
        }
    }
}
