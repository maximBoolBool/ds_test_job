using WeatherServices.Enums;

namespace WeatherServices.Models;

/// <summary>
///     Ответ колекции с пагинацией
/// </summary>
public class PagedListWeatherResponse
{
    /// <summary>
    ///     Коллекция значений
    /// </summary>
    public IEnumerable<WeatherTrackDto> Items { get; set; }

    /// <summary>
    ///     Количестово всех страниц
    /// </summary>
    public int TotalCountPage { get; set; }
    
    /// <summary>
    ///     Текущая страница
    /// </summary>
    public int CurrentPage { get; set; }
    
    /// <summary>
    ///     Тип пагинации
    /// </summary>
    public PaginationType Type { get; set; }
    
    /// .ctor
    public PagedListWeatherResponse(
        IEnumerable<WeatherTrackDto> items,
        int totalCountPage,
        int currentPage,
        PaginationType type)
    {
        CurrentPage = currentPage;
        Items = items;
        TotalCountPage = totalCountPage;
        Type = type;
    }
}