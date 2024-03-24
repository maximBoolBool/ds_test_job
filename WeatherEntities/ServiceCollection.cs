using Microsoft.Extensions.DependencyInjection;
using WeatherEntities.Repositories;
using WeatherEntities.Repositories.Impl;

namespace WeatherEntities;

public static class ServiceCollection
{
    /// <summary>
    ///     Добавить сущности для бд
    /// </summary>
    public static void AddWeatherEntities(this IServiceCollection services)
    {
        services.AddScoped<IFileRepository, FileRepository>();
        services.AddScoped<IWeatherRepository, WeatherRepository>();
        services.AddScoped<IWeatherDbWorker, WeatherDbWorker>();
        services.AddScoped<IWeatherDbWorkerFactory, WeatherDbWorkerFactory>();
    }
}