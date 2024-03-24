using BaseEntities.Entities;

namespace BaseEntities.Repositories;

/// <summary>
///     Репозиторий
/// </summary>
public interface IRepository<TEntity> : IDisposable where TEntity : BaseIdEntity
{
    /// <summary>
    ///     Добавить новые сущности 
    /// </summary>
    Task AddRangeAsync(IEnumerable<TEntity> newEntities, CancellationToken cancellationToken = default);

    /// <summary>
    ///     Поучить коллекцию сущностей     
    /// </summary>
    Task<TEntity[]> ListAsync(CancellationToken cancellationToken = default);

    /// <summary>
    ///     Сохранить
    /// </summary>
    Task SaveChangesAsync(CancellationToken cancellationToken);

    /// <summary>
    ///     Сделать запрос к бд
    /// </summary>
    IQueryable<TEntity> CreateQuery();
}