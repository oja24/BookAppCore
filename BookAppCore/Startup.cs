using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using BookAppCore.Models;
using Microsoft.EntityFrameworkCore;
using BookAppCore.Abstract;

namespace BookAppCore
{
    public class Startup
    {

        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();


        }

        public IConfigurationRoot Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<BookDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("BookDbContext")));
            services.AddTransient<IBookRepository, BookRepository>();
            services.AddTransient<IReviewRepository, ReviewRepository>();
            
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseStaticFiles();
            app.UseBrowserLink();
            app.UseStatusCodePages();


            app.UseMvcWithDefaultRoute();

           // Seeding.EnsuredSeed(app);
        }
    }
}
