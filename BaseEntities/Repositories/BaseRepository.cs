using BaseEntities.Entities;
using Microsoft.EntityFrameworkCore;

namespace BaseEntities.Repositories;

/// <summary>
///     Базовый репозиторий
/// </summary>
public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseIdEntity
{
    #region Fields
    
    protected readonly DbSet<TEntity> DbSet;

    protected readonly DbContext Context;

    #endregion

    #region .ctor

    public BaseRepository(DbContext context)
    {
        DbSet = context.Set<TEntity>();
        Context = context;
    }

    #endregion

    #region Methods

    /// <inheritdoc cref="IRepository{TEntity}"/>
    public async Task AddRangeAsync(IEnumerable<TEntity> newEntities, CancellationToken cancellationToken = default) 
        => await DbSet.AddRangeAsync(newEntities, cancellationToken);

    /// <inheritdoc cref="IRepository{TEntity}"/>
    public Task<TEntity[]> ListAsync(CancellationToken cancellationToken = default)
        => DbSet.ToArrayAsync(cancellationToken);

    /// <inheritdoc cref="IRepository{TEntity}"/>
    public async Task SaveChangesAsync(CancellationToken cancellationToken)
        => await Context.SaveChangesAsync(cancellationToken);

    /// <inheritdoc cref="IRepository{TEntity}"/>
    public IQueryable<TEntity> CreateQuery()
        => Context.Set<TEntity>().AsQueryable();

    public void Dispose()
    {
        Context.Dispose();
    }

    #endregion
}