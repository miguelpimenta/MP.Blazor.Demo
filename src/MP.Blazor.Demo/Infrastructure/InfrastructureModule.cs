using System.Linq;
using Autofac;
using Microsoft.Extensions.Configuration;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Infrastructure.Contexts;
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
                .RegisterType<AppDbContext>()
                .WithParameter("options", DbContextOptionsFactory.Get(_config))
                .InstancePerLifetimeScope();

            builder
                .RegisterAssemblyTypes(currentAssembly)
                .Where(r => r.Name.EndsWith("Repository"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder
                .RegisterType<WeatherForecastService>()
                .As<IWeatherForecastService>()
                .SingleInstance();
        }
    }
}