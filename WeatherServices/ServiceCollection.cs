using Microsoft.Extensions.DependencyInjection;
using WeatherServices.Mappers;
using WeatherServices.Services;
using WeatherServices.Services.Impl;

namespace WeatherServices;

public static class ServiceCollection
{
    /// <summary>
    ///     Добавить сервисы для работы с погодой
    /// </summary>
    public static void AddWeatherServices(this IServiceCollection services)
    {
        services.AddAutoMapper(typeof(WeatherMapperProfile));
        services.AddScoped<IWeatherService, WeatherService>();
    }
}