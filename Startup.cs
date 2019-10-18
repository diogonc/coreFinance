using System.Net;
using System.Threading.Tasks;
using CoreFinance.Filters;
using CoreFinance.Middleware;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

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
            services.AddMvc(options =>
            {
                // options.Filters.Add(new DomainExceptionFilter());
            });
            // .SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddMongo(Configuration.GetSection("Mongo"));
            services.AddDIConfig();
            services.AddCors();

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });

            // services.ConfigureApplicationCookie(config =>
            // {
            //     config.Events = new CookieAuthenticationEvents
            //     {
            //         OnRedirectToLogin = ctx => {
            //             if (ctx.Request.Path.StartsWithSegments("/api"))
            //             {
            //                 ctx.Response.StatusCode = (int)HttpStatusCode.Unauthorized;
            //             }
            //             else {
            //                 ctx.Response.Redirect(ctx.RedirectUri);
            //             }
            //             return Task.FromResult(0);
            //         }
            //     };
            // });
           
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
            }

            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseCors(builder => builder.AllowAnyOrigin()
                                          .AllowAnyMethod()
                                          .AllowAnyHeader()
                        //   WithOrigins("*")
                        //   .WithHeaders("origin", "content-type", "accept", "username",
                        //                "token", "propertyUuid")
                        );

            app.UseMiddleware<AuthMiddleware>();
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
