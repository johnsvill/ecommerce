using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DTOs
{
    public class ProductoDto
    {
        public int Id { get; set; } 
        public string NombreProducto { get; set; }
        public string Descripcion { get; set; }
        public int Stock { get; set; }
        public int IdMarca { get; set; }
        public string Marca { get; set; }
        public int IdCategoria { get; set; }
        public string Categoria { get; set; }
        public decimal Precio { get; set; }
        public string Imagen { get; set; }
    }
}
