using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreData.Entities
{
    [Table("Producto")]
    public class Producto : ClaseBase
    {
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }

        public virtual Marca MarcaLink { get; set; }
        public virtual Categoria CategoriaLink { get; set; }
    }
}
