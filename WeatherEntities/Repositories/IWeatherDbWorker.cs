using BaseEntities;

namespace WeatherEntities.Repositories;

/// <summary>
///     Воркер для бд с погодой
/// </summary>
public interface IWeatherDbWorker : IDbWorker, IDisposable
{
    /// <summary>
    ///     Таблица дней
    /// </summary>
    IWeatherRepository Weathers { get; set; }
    
    IFileRepository Files { get; set; }
}