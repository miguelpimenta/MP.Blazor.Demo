using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

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
}