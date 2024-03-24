using Microsoft.AspNetCore.Mvc;
using WeatherServices.Models.Queries;
using WeatherServices.Models.Requests;
using WeatherServices.Services;

namespace WeatherApp.Controllers;

/// <summary>
///     Контроллер для рабоыт с погодой
/// </summary>
[ApiController]
[Route("weather")]
public class WeatherController : Controller
{
    #region Fields

    private readonly IWeatherService _weatherService;

    #endregion

    #region .ctor

    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }

    #endregion

    #region GET api/weather/main

    /// <summary>
    ///     Получить страницу добавления
    /// </summary>
    [HttpGet("add")]
    public async Task<IActionResult> AddList()
    {
        return View();
    }

    #endregion
    
    #region POST api/weather/add

    /// <summary>
    ///     Добавить новые архивы
    /// </summary>
    [HttpPost("add")]
    public async Task<IActionResult> AddList([FromForm] WeatherAddRequest request, CancellationToken cancellationToken)
    {
        await _weatherService.AddRangeAsync(request, cancellationToken);
        return View();
    }
    
    #endregion

    #region GET api/weather/list

    /// <summary>
    ///     Получить архивы
    /// </summary>
    [HttpGet("list")]
    public async Task<IActionResult> List([FromQuery] DayListQuery query, CancellationToken cancellationToken)
    {
        var contract = await _weatherService.ListAsync(query, cancellationToken);
        return View(contract);
    }

    #endregion
}