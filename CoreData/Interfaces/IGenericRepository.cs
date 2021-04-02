using CoreData.Entities;
using CoreData.Specification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreData.Interfaces
{
    public interface IGenericRepository<T> where T : ClaseBase
    {
        Task<T> GetByIdAsync(int Id);
        Task<IReadOnlyList<T>> GetListAsync();
        Task<T> GetByIdWithSpec(ISpecification<T> spec);
        Task<IReadOnlyList<T>> GetAllWithSpec(ISpecification<T> spec);
        Task<int> CountAsync(ISpecification<T> spec);
    }
}
