using System.ComponentModel.DataAnnotations.Schema;
using BaseEntities.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using WeatherEntities.Enums;

namespace WeatherEntities.Entities;

/// <summary>
///     Погода за один день
/// </summary>
[Table("days")]
public class WeatherTrackEntity : BaseIdEntity
{
    /// <summary>
    ///     Дата
    /// </summary>
    [Column("date")]
    public DateOnly Date { get; set; }
    
    /// <summary>
    ///     Время
    /// </summary>
    [Column("time_only")]
    public TimeOnly Time { get; set; }

    /// <summary>
    ///     Температура
    /// </summary>
    [Column("temperature")]
    public double Temperature { get; set; }
    
    /// <summary>
    ///     Относительная влажность
    /// </summary>
    [Column("relative_humidity")]
    public double RelativeHumidity { get; set; }

    /// <summary>
    ///     Температура росы
    /// </summary>
    [Column("dew_point_temperature")]
    public double DewPointTemperature { get; set; }
    
    /// <summary>
    ///     Давление в милеметрах ртутного столба
    /// </summary>
    [Column("pressure_of_mercury_column")]
    public int PressureOfMercuryColumn { get; set; }
    
    /// <summary>
    ///     Напрвление ветра
    /// </summary>
    [Column("wind_direction")]
    public WindDirectionType WindType { get; set; }
    
    /// <summary>
    ///     Скорость ветра
    /// </summary>
    [Column("wind_speed")]
    public short WindSpeed { get; set; }
    
    /// <summary>
    ///     Измерение длины
    /// </summary>
    [Column("vv_wind_assessment")]
    public MeasureMeasurement VVMeasureMeasurement { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [Column("cloud_cover")]
    public short CloudCover { get; set; }
    
    /// <summary>
    ///     Высота
    /// </summary>
    [Column("height")]
    public int Height { get; set; }
    
    /// <summary>
    ///     Видимость
    /// </summary>
    [Column("visibility_variable")]
    public short VisibilityVariable {get; set; }
    
    /// <summary>
    ///     Погодные явления
    /// </summary>
    [Column("weather_phenomena")]
    public string? WeatherPhenomena { get; set; }

    /// <summary>
    ///     Foreign key для <see cref="FileEntity"/> 
    /// </summary>
    /// <returns></returns>
    [Column("file_id")]
    [ForeignKey(nameof(FileEntity.Id))]
    public long FileId { get; set; }
    
    internal static void SetUp(EntityTypeBuilder<WeatherTrackEntity> builder)
    {
        builder.HasIndex(e => new { e.Date, e.Time })
            .IsUnique()
            .HasName("IX_WeatherTrackEntity_Field1_Field2");
    }
}