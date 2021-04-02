using CoreData.Entities;
using CoreData.Specification;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.Data
{
    //Clase para manejar query dinámico
    public class SpecificationEvaluator<T> where T : ClaseBase
    {
        //Encargado de crear el criterio lógico y las dependencias de Include entre las entidades (Query dinámico)
        public static IQueryable<T> GetQuery(IQueryable<T> inputQuery, ISpecification<T> spec)
        {
            if(spec.Criteria != null)
            {
                inputQuery = inputQuery.Where(spec.Criteria);
            }

            if(spec.OrderBy != null)
            {
                inputQuery = inputQuery.OrderBy(spec.OrderBy);
            }

            if(spec.OrderByDesc != null)
            {
                inputQuery = inputQuery.OrderByDescending(spec.OrderByDesc);
            }

            //Validar si la paginación está habilitada
            if (spec.IsPaginateEnable)
            {
                inputQuery = inputQuery.Skip(spec.Skip).Take(spec.Take);
            }

            inputQuery = spec.Includes.Aggregate(inputQuery, (current, include) => current.Include(include));

            return inputQuery;
        }
    }
}
