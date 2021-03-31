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
    public class MarcasController : ControllerBase
    {
        private readonly IGenericRepository<Marca> _marca;

        public MarcasController(IGenericRepository<Marca> marca)
        {
            this._marca = marca;
        }

        [HttpGet]
        public async Task<ActionResult<IReadOnlyList<Marca>>> GetMarcasAll()
        {
            return Ok(await this._marca.GetListAsync());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Marca>> GetMarcaById(int id)
        {
            return await this._marca.GetByIdAsync(id);
        }
    }
}
