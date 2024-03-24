using BaseEntities;
using WeatherEntities.Repositories;

namespace WeatherEntities;

public interface IWeatherDbWorkerFactory : IDbWorkerFactory<IWeatherDbWorker> { }