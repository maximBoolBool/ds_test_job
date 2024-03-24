using Newtonsoft.Json;

namespace WeatherEntities.Enums;

/// <summary>
///     Типы направления ветра
/// </summary>
public enum WindDirectionType
{
    /// <summary>
    ///     Штиль
    /// </summary>
    [JsonProperty("calm")]
    Calm,
    
    /// <summary>
    ///     Северный
    /// </summary>
    [JsonProperty("notrh")]
    North,
    
    /// <summary>
    ///     Северо-северо-восточный
    /// </summary>
    [JsonProperty("north_north_east")]
    NorthNorthEast,
    
    /// <summary>
    ///     Северо-восточный
    /// </summary>
    [JsonProperty("north_east")]
    NorthEast,
    
    /// <summary>
    ///     Восток-северо-восточный
    /// </summary>
    [JsonProperty("east_north_east")]
    EastNorthEast,
    
    /// <summary>
    ///     Восточный
    /// </summary>
    [JsonProperty("east")]
    East,
    
    /// <summary>
    ///     Восток-юго-восточный
    /// </summary>
    [JsonProperty("east_south_east")]
    EastSouthEast,
    
    /// <summary>
    ///     Юго-восточный
    /// </summary>
    [JsonProperty("south_east")]
    SouthEast,
    
    /// <summary>
    ///     Юго-юго-восточный
    /// </summary>
    [JsonProperty("south_south_east")]
    SouthSouthEast,
    
    /// <summary>
    ///     Южный
    /// </summary>
    [JsonProperty("south")]
    South,
    
    /// <summary>
    ///     Юго-юго-западный
    /// </summary>
    [JsonProperty("south_south_west")]
    SouthSouthWest,
    
    /// <summary>
    ///     Юго-западный
    /// </summary>
    [JsonProperty("south_west")]
    SouthWest,
    
    /// <summary>
    ///     Запад-юго-западый
    /// </summary>
    [JsonProperty("west_south_west")]
    WestSouthWest,
    
    /// <summary>
    ///     Западый
    /// </summary>
    [JsonProperty("west")]
    West,
    
    /// <summary>
    ///     Западно-северо-западный
    /// </summary>
    [JsonProperty("west_north_west")]
    WestNorthWest,
    
    /// <summary>
    ///     Северо-западный
    /// </summary>
    [JsonProperty("north_west")]
    NorthWest,
    
    /// <summary>
    ///     Северо-северо-западный
    /// </summary>
    [JsonProperty("north_north_west")]
    NorthNorthWest
}