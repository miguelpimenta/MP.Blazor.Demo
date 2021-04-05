using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using MP.Blazor.Demo.Core.Application.Contracts;
using MP.Blazor.Demo.Core.Domain.Entities;

namespace MP.Blazor.Demo.Core.Application.Services
{
    public class WeatherForecastService : IWeatherForecastService
    {
        private readonly IRepository<WeatherForecast> _repository;

        public WeatherForecastService(
            IRepository<WeatherForecast> repository)
        {
            _repository = repository;
        }

        public async Task<WeatherForecast[]> GetForecastAsync(DateTime startDate)
        {
            var result = await _repository
                .ListAllAsync(new CancellationToken())
                .ConfigureAwait(false);

            return result.ToArray();
        }
    }
}