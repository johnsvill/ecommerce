using BusinnesLogic.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var Host = CreateHostBuilder(args).Build();//Instancia de Host que ejecuta la app (WebApi)

            using (var Scope = Host.Services.CreateScope())
            {
                var Services = Scope.ServiceProvider;
                var LoggerFactory = Services.GetRequiredService<ILoggerFactory>();

                try
                {
                    var Context = Services.GetRequiredService<NetMarketDbContext>();
                    await Context.Database.MigrateAsync();
                    //await MarketCargarData.CargarDataAsync(Context, LoggerFactory);
                }
                catch (Exception e)
                {
                    var Logger = LoggerFactory.CreateLogger<Program>();
                    Logger.LogError(e, "Errores en el proceso de Migración");

                    throw;
                }
            }

            Host.Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
