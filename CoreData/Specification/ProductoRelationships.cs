using CoreData.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CoreData.Specification
{
    public class ProductoRelationships : BaseSpecification<Producto>
    {
        public ProductoRelationships()
        {
            AddInclude(p => p.CategoriaLink);
            AddInclude(p => p.MarcaLink);
        }

        public ProductoRelationships(int id) : base(x => x.Id == id)
        {
            AddInclude(p => p.CategoriaLink);
            AddInclude(p => p.MarcaLink);
        }
    }
}
