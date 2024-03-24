using Microsoft.EntityFrameworkCore;
using WeatherEntities.Entities;

namespace WeatherEntities;

/// <summary>
///     Контекст для работы с бд
/// </summary>
public class WeatherDbContext : DbContext
{
    #region .ctor
    
    public WeatherDbContext() : base() { }
    
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options) { }
    
    #endregion

    #region Tables

    public DbSet<WeatherTrackEntity> WeatherTrack { get; set; } = null!;

    public DbSet<FileEntity> Files { get; set; } = null!;

    #endregion

    #region Overrides

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=proxy_db;Username=postgres;Password=panzer117");
        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        WeatherTrackEntity.SetUp(modelBuilder.Entity<WeatherTrackEntity>());
        FileEntity.SetUp(modelBuilder.Entity<FileEntity>());
        base.OnModelCreating(modelBuilder);
    }

    #endregion
}