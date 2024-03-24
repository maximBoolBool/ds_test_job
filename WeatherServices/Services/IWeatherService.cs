using WeatherServices.Models;
using WeatherServices.Models.Queries;
using WeatherServices.Models.Requests;

namespace WeatherServices.Services;

/// <summary>
///     Сервис для работы с погодой
/// </summary>
public interface IWeatherService
{
    /// <summary>
    ///     Добавить новые дни с погодой
    /// </summary>
    Task AddRangeAsync(WeatherAddRequest request,CancellationToken cancellationToken = default);

    /// <summary>
    ///     Получить дни с фильтрацией
    /// </summary>
    Task<PagedListWeatherResponse> ListAsync(DayListQuery query, CancellationToken cancellationToken = default);
}