using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.DependencyInjection;
using BookAppCore.Models;
using BookAppCore.Data;

namespace BookAppCore
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var host = BuildWebHost(args);
                //.Run();
                using(var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<BookDbContext>();
                    SeedingData.Initializer(context);
                }
                catch (Exception EX)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(EX, "An error occured while deeding the database.");
                }
            }
            host.Run();
        }




        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
             .UseDefaultServiceProvider(options => options.ValidateScopes = false)
                .Build();
    }
}
