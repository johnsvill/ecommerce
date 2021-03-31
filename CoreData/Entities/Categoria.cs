using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreData.Entities
{
    [Table("Categoria")]
    public class Categoria : ClaseBase
    {
        public string NombreCategoria { get; set; }
    }
}
