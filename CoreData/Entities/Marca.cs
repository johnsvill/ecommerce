using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreData.Entities
{
    [Table("Marca")]
    public class Marca : ClaseBase
    {
        public string MarcaProducto { get; set; }
    }
}
