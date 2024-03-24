using Newtonsoft.Json;
using WeatherEntities.Enums;

namespace WeatherServices.Models;

/// <summary>
///     Ответ на получение погоды
/// </summary>
public class WeatherTrackDto
{
    /// <summary>
    ///     Id
    /// </summary>
    [JsonProperty("id")]
    public long Id { get; set; }
    
    /// <summary>
    ///     Дата
    /// </summary>
    [JsonProperty("date")]
    public DateOnly Date { get; set; }
    
    /// <summary>
    ///     Время
    /// </summary>
    [JsonProperty("time_only")]
    public TimeOnly Time { get; set; }

    /// <summary>
    ///     Температура
    /// </summary>
    [JsonProperty("temperature")]
    public short Temperature { get; set; }
    
    /// <summary>
    ///     Относительная влажность
    /// </summary>
    [JsonProperty("relative_humidity")]
    public double RelativeHumidity { get; set; }

    /// <summary>
    ///     Температура росы
    /// </summary>
    [JsonProperty("dew_point_temperature")]
    public double DewPointTemperature { get; set; }
    
    /// <summary>
    ///     Давление в милеметрах ртутного столба
    /// </summary>
    [JsonProperty("pressure_of_mercury_column")]
    public int PressureOfMercuryColumn { get; set; }
    
    /// <summary>
    ///     Напрвление ветра
    /// </summary>
    [JsonProperty("wind_direction")]
    public WindDirectionType WindType { get; set; }
    
    /// <summary>
    ///     Скорость ветра
    /// </summary>
    [JsonProperty("wind_speed")]
    public short WindSpeed { get; set; }
    
    /// <summary>
    ///     Мера измерения видимости
    /// </summary>
    [JsonProperty("wind_assessment")]
    public MeasureMeasurement VVMeasureMeasurement { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    [JsonProperty("cloud_cover")]
    public short CloudCover { get; set; }
    
    /// <summary>
    ///     Высота
    /// </summary>
    [JsonProperty("height")]
    public int Height { get; set; }
    
    /// <summary>
    ///     Видимость
    /// </summary>
    [JsonProperty("visibility_variable")]
    public short VisibilityVariable {get; set; }
    
    /// <summary>
    ///     Погодные явления
    /// </summary>
    [JsonProperty("weather_phenomena")]
    public string? WeatherPhenomena { get; set; }
}