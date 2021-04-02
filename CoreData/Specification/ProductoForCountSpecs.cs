using CoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreData.Specification
{
    public class ProductoForCountSpecs : BaseSpecification<Producto>
    {
        public ProductoForCountSpecs(ProductoSpecParams productoParams)
             : base(x =>
             (string.IsNullOrEmpty(productoParams.Search) || x.NombreProducto.Contains(productoParams.Search))
              &&
             (!productoParams.Marca.HasValue || x.IdMarca == productoParams.Marca) &&
                  (!productoParams.Categoria.HasValue || x.IdCategoria == productoParams.Categoria))             
        {

        }
    }
}
