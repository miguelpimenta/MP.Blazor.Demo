using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace MP.Blazor.Demo.Infrastructure.Contexts
{
    public static class DbContextOptionsFactory
    {
        public static DbContextOptions<AppDbContext> Get(IConfiguration _config)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();

            DbContextConfigurer.Configure(
                builder,
                _config.GetSection("ConnectionStrings:SqliteConnection").Value);

            return builder.Options;
        }
    }

    public static class DbContextConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<AppDbContext> builder,
            string connectionString)
        {
            builder
                .UseSqlite(connectionString);
        }
    }

    internal static class ModelBuilderExtension
    {
        private static IEnumerable<Type> _types;

        public static void RegisterAllEntities<TBaseType>(
            this ModelBuilder modelBuilder)
        {
            if (_types != null)
            {
                return;
            }

            _types = AppDomain
                    .CurrentDomain
                    .GetAssemblies()
                    .Where(assembly =>
                    {
                        var name = assembly.GetName().Name;

                        return name?
                            .StartsWith(typeof(AppDbContext).Namespace?
                            .Split('.')[0] ?? string.Empty) == true;
                    })
                    .SelectMany(a => a.GetExportedTypes())
                    .Where(c => c.IsClass &&
                                !c.IsAbstract &&
                                c.IsPublic &&
                                typeof(TBaseType).IsAssignableFrom(c));

            foreach (var type in _types)
            {
                Log.Information($"Registering type [{type}]...");

                modelBuilder.Entity(type);
            }
        }
    }
}