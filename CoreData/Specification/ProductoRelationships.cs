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
        //string sort, int? marca, int? categoria
        public ProductoRelationships(ProductoSpecParams productoParams)
            :base (x => 
            (string.IsNullOrEmpty(productoParams.Search) || x.NombreProducto.Contains(productoParams.Search))
            &&
            (!productoParams.Marca.HasValue || x.IdMarca == productoParams.Marca) &&
            (!productoParams.Categoria.HasValue || x.IdCategoria == productoParams.Categoria))            
        {
            AddInclude(p => p.CategoriaLink);
            AddInclude(p => p.MarcaLink);
            //AddOrderBy(p => p.NombreProducto);
            //ApplyPaginate(0, 5);//Paginación con valores quemados
            ApplyPaginate(productoParams.PageSize * (productoParams.PageIndex -1), productoParams.PageSize);

            if (!string.IsNullOrEmpty(productoParams.Sort))
            {
                switch (productoParams.Sort)
                {
                    case "precioAsc":
                        AddOrderBy(p => p.Precio);
                        break;
                    case "precioDesc":
                        AddOrderByDesc(p => p.Precio);
                        break;
                    case "descripcionAsc":
                        AddOrderBy(p => p.Descripcion);
                        break;
                    case "descripcionDesc":
                        AddOrderByDesc(p => p.Descripcion);
                        break;
                    case "nombreAsc":
                        AddOrderBy(p => p.NombreProducto);
                        break;
                    case "nombreDesc":
                        AddOrderByDesc(p => p.NombreProducto);
                        break;
                    default:
                        AddOrderBy(p => p.NombreProducto);
                        break;
                }
            }
        }

        public ProductoRelationships(int id) : base(x => x.Id == id)//Llama al constructor padre por herencia
        {
            AddInclude(p => p.CategoriaLink);
            AddInclude(p => p.MarcaLink);
            AddOrderBy(p => p.NombreProducto);
        }
    }
}
