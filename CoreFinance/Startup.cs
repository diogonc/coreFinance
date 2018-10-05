﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CoreFinance.Middleware;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Infra.Repositories.Sql;
using Microsoft.EntityFrameworkCore;

namespace CoreFinance
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }
        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddDbContext<FinanceContext>();
            services.AddMongo(Configuration.GetSection("Mongo"));
            services.AddDIConfig();
            services.AddCors();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));

            app.UseCors(builder => builder.WithOrigins("http://localhost:4200", "http://diogonc.github.io", "https://diogonc.github.io")
                                          .AllowAnyMethod()
                                          .WithHeaders("origin", "content-type", "accept", "username",
                                                       "token", "propertyUuid")
            );

            app.UseMiddleware<AuthMiddleware>();
            app.UseMvc();
        }
    }
}
