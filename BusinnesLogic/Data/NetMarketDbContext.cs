using CoreData.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BusinnesLogic.Data
{
    public class NetMarketDbContext : DbContext
    {
        //Constructor nulo o por defecto
        public NetMarketDbContext()
        {

        }

        public NetMarketDbContext(DbContextOptions<NetMarketDbContext> options) : base(options)
        {

        }

        public DbSet<Producto> ProductosDb { get; set; }
        public DbSet<Marca> MarcasDb { get; set; }
        public DbSet<Categoria> CategoriasDb { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());//Para que llame a todas las clases que heredan del IEntityTypeConfiguration
        }      
    }
}
