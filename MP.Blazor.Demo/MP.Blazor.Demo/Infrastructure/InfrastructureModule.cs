using System.Linq;
using Autofac;
using Microsoft.Extensions.Configuration;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Infrastructure.Data;

namespace MP.Blazor.Demo.Infrastructure
{
    public class InfrastructureModule : Module
    {
        private readonly IConfiguration _config;

        public InfrastructureModule(IConfiguration config)
        {
            _config = config;
        }

        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder
                .RegisterAssemblyTypes(currentAssembly)
                .Where(r => r.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<WeatherForecastService>()
                .As<IWeatherForecastService>()
                .SingleInstance();

            //            builder
            //                .Register<ILogger>((c, p) =>
            //            {
            //                return new LoggerConfiguration()
            //#if DEBUG
            //                    .MinimumLevel.Debug()
            //#else
            //                    .MinimumLevel.Override("Microsoft", LogEventLevel.Warning)
            //                    .MinimumLevel.Override("System", LogEventLevel.Warning)
            //                    .MinimumLevel.Override("Microsoft.AspNetCore.Authentication", LogEventLevel.Information)
            //#endif
            //                    .Enrich.FromLogContext()
            //                    .WriteTo
            //                        .Console(
            //                            outputTemplate: "[{Timestamp:HH:mm:ss} {Level}] {SourceContext}{NewLine}{Message:lj}{NewLine}{Exception}{NewLine}",
            //                            theme: AnsiConsoleTheme.Literate)
            //                    .CreateLogger();
            //            }).SingleInstance();
        }
    }
}