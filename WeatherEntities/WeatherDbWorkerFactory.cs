using BaseEntities;
using Microsoft.Extensions.DependencyInjection;
using WeatherEntities.Repositories;

namespace WeatherEntities;

/// <inheritdoc cref="BaseWorkerDbFactory{T}"/>
public class WeatherDbWorkerFactory : BaseWorkerDbFactory<IWeatherDbWorker>, IWeatherDbWorkerFactory
{
    public WeatherDbWorkerFactory(IServiceScopeFactory scopeFactory) : base(scopeFactory) { }
}