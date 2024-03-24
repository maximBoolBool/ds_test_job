using Newtonsoft.Json;

namespace WeatherServices.Enums;

/// <summary>
///     Тип просмотра
/// </summary>
public enum PaginationType
{
    /// <summary>
    ///     По месячно
    /// </summary>
    [JsonProperty("month")]
    Month,
    
    /// <summary>
    ///  По годично
    /// </summary>
    [JsonProperty("year")]
    Year,
}