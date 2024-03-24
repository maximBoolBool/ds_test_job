using BaseEntities.Repositories;
using WeatherEntities.Entities;

namespace WeatherEntities.Repositories;

/// <summary>
///     Репозиторий для работы с <see cref="FileEntity"/>
/// </summary>
public interface IFileRepository : IRepository<FileEntity>
{
    /// <summary>
    ///     Получить файл по имени 
    /// </summary>
    Task<FileEntity?> GetByNameAsync(string name);
}