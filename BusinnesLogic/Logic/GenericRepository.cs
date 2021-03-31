using BusinnesLogic.Data;
using CoreData.Entities;
using CoreData.Interfaces;
using CoreData.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.Logic
{
    public class GenericRepository<T> : IGenericRepository<T> where T : ClaseBase
    {
        private readonly NetMarketDbContext _dbContext;

        public GenericRepository(NetMarketDbContext dbContext)
        {
            this._dbContext = dbContext;
        }        

        public async Task<T> GetByIdAsync(int id)
        {
            return await this._dbContext.Set<T>().FindAsync(id);
        }      

        public async Task<IReadOnlyList<T>> GetListAsync()
        {
            return await this._dbContext.Set<T>().ToListAsync();
        }

        public async Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public async Task<T> GetByIdWithSpec(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).FirstOrDefaultAsync();
        }

        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(this._dbContext.Set<T>().AsQueryable(), spec);
        }
    }
}
