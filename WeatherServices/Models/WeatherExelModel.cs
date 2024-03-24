using WeatherEntities.Enums;

namespace WeatherServices.Models;

/// <summary>
///     Модель дня
/// </summary>
public class WeatherExelModel
{
    /// <summary>
    ///     Дата
    /// </summary>
    public DateOnly Date { get; set; }

    /// <summary>
    ///     Время
    /// </summary>
    public TimeOnly Time { get; set; }

    /// <summary>
    ///     Температура
    /// </summary>
    public double Temperature { get; set; }

    /// <summary>
    ///     Относительная влажность
    /// </summary>
    public double RelativeHumidity { get; set; }

    /// <summary>
    ///     Температура росы
    /// </summary>
    public double DewPointTemperature { get; set; }

    /// <summary>
    ///     Давление в милеметрах ртутного столба
    /// </summary>
    public int PressureOfMercuryColumn { get; set; }

    /// <summary>
    ///     Напрвление ветра
    /// </summary>
    public WindDirectionType WindType { get; set; }

    /// <summary>
    ///     Скорость ветра
    /// </summary>
    public short WindSpeed { get; set; }

    /// <summary>
    ///     Облачность
    /// </summary>
    public short CloudCover { get; set; }

    /// <summary>
    ///     Высота
    /// </summary>
    public int Height { get; set; }

    /// <summary>
    ///     Видимость
    /// </summary>
    public short VisibilityVariable {get; set; }

    /// <summary>
    ///     Мера измерения видимости
    /// </summary>
    public MeasureMeasurement VVAssessment { get; set; }
    
    /// <summary>
    ///     Погодные явления
    /// </summary>
    public string? WeatherPhenomena { get; set; }
}