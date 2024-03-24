using BaseEntities.Repositories;
using Microsoft.EntityFrameworkCore;
using WeatherEntities.Entities;

namespace WeatherEntities.Repositories.Impl;

/// <inheritdoc cref="IFileRepository"/>
public class FileRepository : BaseRepository<FileEntity>, IFileRepository
{
    /// .ctor
    public FileRepository(WeatherDbContext context) : base(context) { }

    /// <inheritdoc cref="IFileRepository"/>
    public async Task<FileEntity?> GetByNameAsync(string name)
        => await DbSet.FirstOrDefaultAsync(e => e.Name == name);
}