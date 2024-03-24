using Microsoft.AspNetCore.Http;

namespace WeatherServices.Models.Requests;

/// <summary>
///     Запрос на добавление новых дней с погодой
/// </summary>
public class WeatherAddRequest
{
    /// <summary>
    ///     Файлы
    /// </summary>
    public IFormFile[] files { get; set; }
}