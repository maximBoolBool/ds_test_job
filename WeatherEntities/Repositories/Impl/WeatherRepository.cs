using BaseEntities.Repositories;
using WeatherEntities.Entities;

namespace WeatherEntities.Repositories.Impl;

/// <inheritdoc cref="BaseRepository{TEntity}"/>
public class WeatherRepository : BaseRepository<WeatherTrackEntity>, IWeatherRepository
{
    /// <inheritdoc cref="BaseRepository{TEntity}"/>
    public WeatherRepository(WeatherDbContext context) : base(context) { }

    public async Task<IEnumerable<WeatherTrackEntity>> GetPerTimeInterval(CancellationToken cancellationToken = default)
    {
        throw new NotImplementedException();
    }
}