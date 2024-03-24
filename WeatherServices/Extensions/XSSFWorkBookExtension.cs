using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;

namespace WeatherServices.Extensions;

/// <summary>
///     Методы расширения для <see cref="XSSFWorkBook"/>
/// </summary>
public static class XSSFWorkBookExtension
{
    public static IEnumerable<ISheet> GetAllSheets(this XSSFWorkbook book) 
        => Enumerable.Range(0, book.NumberOfSheets).Select(i => book.GetSheetAt(i));
}