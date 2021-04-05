using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MP.Blazor.Demo.Core.Domain.Entities;

namespace MP.Blazor.Demo.Infrastructure.Configurations
{
    public class WeatherForecastConfig : IEntityTypeConfiguration<WeatherForecast>
    {
        void IEntityTypeConfiguration<WeatherForecast>.Configure(EntityTypeBuilder<WeatherForecast> builder)
        {
            builder
                .ToTable(name: "WeatherForecasts", schema: "dbo");

            builder
                .HasKey(x => x.Id);

            builder
                .Property(x => x.Id)
                .ValueGeneratedOnAdd();

            builder
                 .HasData(
                 new WeatherForecast
                 {
                     Id = Guid.Parse("688A4BAB-15A2-4159-BDF8-83CD551995BA"),
                     Date = new DateTime(2021, 3, 1, 12, 0, 0),
                     TemperatureC = -9,
                     Summary = "Sweltering"
                 },
                 new WeatherForecast
                 {
                     Id = Guid.Parse("AADF65A8-D14D-4F87-B25A-CC0B7741DB60"),
                     Date = new DateTime(2021, 3, 2, 12, 0, 0),
                     TemperatureC = -20,
                     Summary = "Balmy"
                 },
                 new WeatherForecast
                 {
                     Id = Guid.Parse("8BEFCB97-6CDF-4A40-9511-9197BA715379"),
                     Date = new DateTime(2021, 3, 3, 12, 0, 0),
                     TemperatureC = -18,
                     Summary = "Scorching"
                 },
                 new WeatherForecast
                 {
                     Id = Guid.Parse("810A8C8B-6379-42A9-A223-5F41DFF28769"),
                     Date = new DateTime(2021, 3, 4, 12, 0, 0),
                     TemperatureC = 34,
                     Summary = "Bracing"
                 },
                 new WeatherForecast
                 {
                     Id = Guid.Parse("11063071-7EBA-401E-83C7-F411776EADA5"),
                     Date = new DateTime(2021, 3, 5, 12, 0, 0),
                     TemperatureC = -12,
                     Summary = "Freezing"
                 });
        }
    }
}