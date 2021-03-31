using System;
using System.Net;
using System.Net.Http;
using System.Reflection;
using Autofac;
using Fluxor;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using MP.Blazor.Demo.Core;
using MP.Blazor.Demo.Infrastructure;
using MudBlazor.Services;

namespace MP.Blazor.Demo
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public ILifetimeScope AutofacContainer { get; private set; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();
            services.AddServerSideBlazor();

            //! Http Client
            services.AddScoped(_ =>
            {
                return new HttpClient
                {
                    BaseAddress = new Uri(Configuration.GetSection("BaseAddress").Value),
                    DefaultRequestVersion = HttpVersion.Version20
                };
            });

            services.AddMudServices();

            //! Fluxor
            services.AddFluxor(options =>
            {
                options.ScanAssemblies(Assembly.GetExecutingAssembly());
#if DEBUG
                options.UseReduxDevTools();
#endif
            });
        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            //! Autofac container
            builder.RegisterModule(new CoreModule());
            builder.RegisterModule(new InfrastructureModule(Configuration));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapBlazorHub();
                endpoints.MapFallbackToPage("/_Host");
            });
        }
    }
}