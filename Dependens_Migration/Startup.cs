﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dependens_Migration.DAL;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Dependens_Migration
{
    public class Startup
    {
        private IConfiguration _config;
        public Startup(IConfiguration configuration)
        {
            _config = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<AppDbContext>(options=> {
                options.UseSqlServer(_config["ConnectionStrings:DefaultConnection"]);


            });


            // Services Life Time
            //services.AddScoped<>();
            //services.AddSingleton<>();
            //services.AddTransient<>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();

            }


            app.UseStaticFiles();

            app.UseMvc(routes=>
            {
                routes.MapRoute(
                    "default",
                    "{controller=Home}/{action=Index}/{id?}"
                    
                    );
            });
            
        }
    }
}
