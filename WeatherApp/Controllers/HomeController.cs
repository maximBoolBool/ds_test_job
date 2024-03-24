using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using WeatherApp.Models;

namespace WeatherApp.Controllers;

/// <summary>
///     Контроллер для основной страницы
/// </summary>
public class HomeController : Controller
{
    /// <summary>
    ///     Отобразить основную страницу
    /// </summary>
    public IActionResult Index()
    {
        return View();
    }
    
    /// <summary>
    ///     Отобразить страницу с ошибкой
    /// </summary>
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}