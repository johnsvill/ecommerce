using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CoreData.Specification
{
    public interface ISpecification<T>
    {
        Expression<Func<T, bool>> Criteria { get; }//Representa el criterio que le aplicas a una entidad, o los filtro para una consulta
        List<Expression<Func<T, object>>> Includes { get; }//Representa las relaciones que se pueden implementar sobre la entidad

        Expression<Func<T, object>> OrderBy { get; }
        Expression<Func<T, object>> OrderByDesc { get; }    

        int Take { get; }
        int Skip { get; }
        bool IsPaginateEnable { get; }
    }
}
