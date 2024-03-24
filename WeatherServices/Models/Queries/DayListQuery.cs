using Newtonsoft.Json;
using WeatherServices.Enums;

namespace WeatherServices.Models.Queries;

/// <summary>
///     Запрос на получение дней
/// </summary>
public class DayListQuery
{
    /// <summary>
    ///     Тип пагинации
    /// </summary>
    [JsonProperty("type")]
    public PaginationType Type { get; set; }

    /// <summary>
    ///     Номер выбранной страницы
    /// </summary>
    [JsonProperty("page_number")]
    public int PageNumber { get; set; }
}