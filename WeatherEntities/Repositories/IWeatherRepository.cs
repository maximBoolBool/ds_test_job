using BaseEntities.Repositories;
using WeatherEntities.Entities;

namespace WeatherEntities.Repositories;

/// <inheritdoc cref="IRepository{TEntity}"/>
public interface IWeatherRepository : IRepository<WeatherTrackEntity> { }