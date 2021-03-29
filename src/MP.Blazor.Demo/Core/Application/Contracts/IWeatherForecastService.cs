using System;
using System.Threading.Tasks;
using MP.Blazor.Demo.Core.Domain.Entities;

namespace MP.Blazor.Demo.Core.Application.Contracts
{
    public interface IWeatherForecastService
    {
        Task<WeatherForecast[]> GetForecastAsync(DateTime startDate);
    }
}