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
        Expression<Func<T, bool>> Criteria { get; }//Representa el criterio que le aplicas a una entidad
        List<Expression<Func<T, object>>> Includes { get; }//Representa las relaciones que se pueden implementar sobre la entidad
    }
}
