using BusinnesLogic.Data;
using CoreData.Entities;
using CoreData.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.Logic
{
    public class ProductoRepository : IProductoRepository
    {
        private readonly NetMarketDbContext _dbContext;

        public ProductoRepository(NetMarketDbContext dbContext)
        {
            this._dbContext = dbContext;
        }

        public async Task<IReadOnlyList<Producto>> GetListProductosAsync()
        {
            //return await this._dbContext.ProductosDb.ToListAsync();
            return await this._dbContext.ProductosDb
                .Include(p => p.MarcaLink)
                .Include(p => p.CategoriaLink)
                .ToListAsync();
        }

        public async Task<Producto> GetProductoByIdAsync(int Id)
        {
            return await this._dbContext.ProductosDb
                .Include(p => p.MarcaLink)
                .Include(p => p.CategoriaLink)
                .FirstOrDefaultAsync(p => p.Id == Id);
        }
    }
}
