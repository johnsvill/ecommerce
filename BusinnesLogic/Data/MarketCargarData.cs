using CoreData.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinnesLogic.Data
{
    public class MarketCargarData
    {
        public static async Task CargarDataAsync(NetMarketDbContext dbContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!dbContext.MarcasDb.Any())
                {
                    var DataMarca = File.ReadAllText("../BusinnesLogic/CargarData/marca.json");
                    var Marcas = JsonSerializer.Deserialize<List<Marca>>(DataMarca);

                    foreach(var m in Marcas)
                    {
                        dbContext.MarcasDb.Add(m);
                    }

                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.ProductosDb.Any())
                {
                    var DataProducto = File.ReadAllText("../BusinnesLogic/CargarData/producto.json");
                    var Productos = JsonSerializer.Deserialize<List<Producto>>(DataProducto);

                    foreach (var p in Productos)
                    {
                        dbContext.ProductosDb.Add(p);
                    }

                    await dbContext.SaveChangesAsync();
                }

                if (!dbContext.CategoriasDb.Any())
                {
                    var DataCategoria = File.ReadAllText("../BusinnesLogic/CargarData/categoria.json");
                    var Categorias = JsonSerializer.Deserialize<List<Categoria>>(DataCategoria);

                    foreach (var c in Categorias)
                    {
                        dbContext.CategoriasDb.Add(c);
                    }

                    await dbContext.SaveChangesAsync();
                }
            }
            catch (Exception e)
            {
                var logger = loggerFactory.CreateLogger<MarketCargarData>();

                logger.LogError(e.Message);
                throw;
            }
        }
    }
}
