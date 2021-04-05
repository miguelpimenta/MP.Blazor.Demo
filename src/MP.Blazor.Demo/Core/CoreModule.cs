using Autofac;
using AutoMapper.Contrib.Autofac.DependencyInjection;
using MediatR.Extensions.Autofac.DependencyInjection;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Core.Application.Services;

namespace MP.Blazor.Demo.Core
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            var currentAssembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAutoMapper(currentAssembly);

            builder.RegisterMediatR(currentAssembly);

            //! User Service
            builder
                .RegisterType<UserService>()
                .As(typeof(IUserService))
                .InstancePerLifetimeScope();

            builder
                .RegisterType<WeatherForecastService>()
                .As(typeof(IWeatherForecastService))
                .InstancePerLifetimeScope();
        }
    }
}