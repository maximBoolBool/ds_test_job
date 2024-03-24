using BaseEntities;

namespace WeatherEntities.Repositories.Impl;

/// <inheritdoc cref="IDbWorker"/>
internal class WeatherDbWorker : IWeatherDbWorker
{
    #region Fields

    /// <inheritdoc cref="IWeatherDbWorker"/>
    public IWeatherRepository Weathers { get; set; }
    
    /// <inheritdoc cref="IFileRepository"/>
    public IFileRepository Files { get; set; }

    #endregion

    #region .ctor
    
    public WeatherDbWorker(IWeatherRepository weathersRepository, IFileRepository files)
    {
        Weathers = weathersRepository;
        Files = files;
    }

    #endregion

    public void Dispose()
    {
        Weathers.Dispose();
        Files.Dispose();
    }
}