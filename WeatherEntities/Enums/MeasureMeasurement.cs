using Newtonsoft.Json;

namespace WeatherEntities.Enums;

/// <summary>
///     Мера измерения длины
/// </summary>
public enum MeasureMeasurement
{
    /// <summary>
    ///     Километры
    /// </summary>
    [JsonProperty("kilometrs")]
    Kilometers,
    
    /// <summary>
    ///     Метры
    /// </summary>
    [JsonProperty("metrs")]
    Metrs,
}