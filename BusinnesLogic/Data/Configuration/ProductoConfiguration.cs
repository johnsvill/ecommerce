using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CoreData.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BusinnesLogic.Data.Configuration
{
    public class ProductoConfiguration : IEntityTypeConfiguration<Producto>
    {
        public void Configure(EntityTypeBuilder<Producto> builder)
        {
            builder.Property(p => p.NombreProducto).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Descripcion).IsRequired().HasMaxLength(250);
            builder.Property(p => p.Imagen).HasMaxLength(1000);
            builder.Property(p => p.Precio).HasColumnType("decimal(18,2)");
            builder.HasOne(m => m.MarcaLink).WithMany().HasForeignKey(p => p.IdMarca);
            builder.HasOne(c => c.CategoriaLink).WithMany().HasForeignKey(c => c.IdCategoria);
        }
    }
}
