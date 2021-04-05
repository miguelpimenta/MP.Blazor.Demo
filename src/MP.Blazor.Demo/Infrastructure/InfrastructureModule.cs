using System;
using System.Net;
using System.Net.Http;
using Autofac;
using Microsoft.Extensions.Configuration;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Infrastructure.Contexts;
using MP.Blazor.Demo.Infrastructure.Repositories;

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

            builder.RegisterGeneric(typeof(Repository<>))
                .As(typeof(IRepository<>))
                .InstancePerLifetimeScope();

            builder.Register(_ => new HttpClient()
            {
                BaseAddress = new Uri(_config.GetSection("BaseAddress").Value),
                DefaultRequestVersion = HttpVersion.Version20
            })
                .InstancePerLifetimeScope();
        }
    }
}