using BaseEntities;
using Microsoft.Extensions.DependencyInjection;

namespace WeatherEntities.Repositories.Impl;

/// <inheritdoc cref="BaseWorkerDbFactory{TDbWorker}"/>
public class WeatherDbWorkerFactory : BaseWorkerDbFactory<IWeatherDbWorker>
{
    public WeatherDbWorkerFactory(IServiceScopeFactory scopeFactory) : base(scopeFactory) { }
}