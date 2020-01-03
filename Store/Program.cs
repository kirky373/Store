using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using Store.ReviewData;

namespace Store
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = CreateWebHostBuilder(args).Build();

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                var env = services.GetRequiredService<IHostingEnvironment>();
                if (env.IsDevelopment())
                {
                    var context = services.GetRequiredService<ReviewDbContext>();
                    context.Database.Migrate(); // Run pre-generated migrations using *Add-Migration InitialCreate*
                    try
                    {
                        ReviewDbInitialiser.Seed(context).Wait();
                    }
                    catch (Exception e)
                    {
                        var exception = e.Message;
                        var logger = services.GetRequiredService<ILogger<Program>>();
                        logger.LogDebug("Seeding test data failed.");
                    }
                }
            }


            host.Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
