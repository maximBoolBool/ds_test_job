using System.ComponentModel.DataAnnotations.Schema;
using BaseEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace WeatherEntities.Entities;

/// <summary>
///     Распарсеррые архивы
/// </summary>
[Table("files")]
public class FileEntity : BaseIdEntity
{
    /// <summary>
    ///     Имя файла
    /// </summary>
    [Column("name")]
    public string Name { get; set; }
    
    /// <summary>
    ///     Дата добавления
    /// </summary>
    [Column("upload_date")]
    public DateTime UploadDate { get; set; } = DateTime.UtcNow;

    /// <summary>
    ///     Навигационное свойство для <see cref="WeatherTrackEntity"/>
    /// </summary>
    public List<WeatherTrackEntity> Weather { get; set; }

    internal static void SetUp(EntityTypeBuilder<FileEntity> builder)
    {
        builder
            .HasMany(o => o.Weather)
            .WithOne()
            .HasForeignKey(nameof(WeatherTrackEntity.FileId))
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasIndex(e => e.Name).IsUnique();
    }
}