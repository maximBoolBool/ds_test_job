using System.Globalization;
using NPOI.SS.UserModel;
using WeatherEntities.Enums;

namespace WeatherServices.Extensions;

/// <summary>
///  Хелперы для <see cref="NPOI.XWPF.UserModel.ICell"/>
/// </summary>
public static class CellExtension
{
    /// <summary>
    ///     Получить значение DateOnly из ячейки
    /// </summary>
    public static DateOnly GetDateOnlyValue(this ICell cell)
    {
        var cellValue = cell.StringCellValue;
        if (DateOnly.TryParseExact(cellValue, "dd.MM.yyyy", out var date))
        {
            return date;
        }

        throw new ArgumentException("Not valid date format");
    }
    
    /// <summary>
    ///     Получить значение TimeOnly из ячейки
    /// </summary>
    public static TimeOnly GetTimeOnlyValue(this ICell cell)
    {
        var cellValue = cell.StringCellValue;
        if (TimeOnly.TryParseExact(cellValue, "HH:mm", null, DateTimeStyles.None, out var value))
        {
            return value;
        }

        throw new ArgumentException("Not valid time format");
    }
    
    /// <summary>
    ///     Получить значение int из ячейки
    /// </summary>
    public static int GetIntValue(this ICell cell)
    {
        switch (cell.CellType)
        {
            case CellType.Numeric:
                return (int)cell.NumericCellValue;

            case CellType.String:
                var caseValue = cell.StringCellValue;
                if (caseValue == null || caseValue == " ")
                {
                    return 0;
                }
                if (int.TryParse(caseValue, out var value))
                    return value;

                throw new ArgumentException($"Value {caseValue} is invalid");
            
            default:
                throw new ArgumentException("Invalid value for integer type");
        }
    }
    
    /// <summary>
    ///     Получить значение short из ячейки
    /// </summary>
    /// Некоторые ячейки имеют текстовый формат некоторые численный, не уверен, что это сделанно специально
    /// по условию задачи
    public static short GetShortValue(this ICell cell)
    {
        switch (cell.CellType)
        {
            case CellType.Numeric:
                return (short)cell.NumericCellValue;

            case CellType.String:
                var caseValue = cell.StringCellValue;
                if (caseValue == null || caseValue == " ")
                {
                    return 0;
                }
                if (short.TryParse(caseValue, out var value))
                    return value;

                throw new ArgumentException($"Value {caseValue} is invalid");
            
            default:
                throw new ArgumentException("Invalid value for integer type");
        }
    }
    
    /// <summary>
    ///     Получить значение направления ветра из ячейки
    /// </summary>
    public static WindDirectionType GetWindValue(this ICell cell)
    {
        if (cell.CellType == CellType.String)
        {
            var value = cell.StringCellValue;
            switch (value)
            {
                case "С" :
                    return WindDirectionType.North;                
                case "СВ" :
                    return WindDirectionType.NorthEast;                
                case "С,CВ" :
                    return WindDirectionType.NorthNorthEast;                
                case "В,СВ" :
                    return WindDirectionType.NorthWest;                
                case "В" :
                    return WindDirectionType.NorthNorthWest;                
                case "В,ЮВ" :
                    return WindDirectionType.East;                
                case "ЮВ" :
                    return WindDirectionType.East;                
                case "Ю,ЮВ" :
                    return WindDirectionType.East;                
                case "Ю" :
                    return WindDirectionType.East;                
                case "Ю,ЮЗ" :
                    return WindDirectionType.East;
                case "З,ЮЗ" :
                    return WindDirectionType.East;                
                case "З" :
                    return WindDirectionType.East;                
                case "З,СЗ" :
                    return WindDirectionType.East;                
                case "СЗ" :
                    return WindDirectionType.East;                
                case "С,СЗ" :
                    return WindDirectionType.East;
                default:
                    return WindDirectionType.Calm;
            }    
        }

        throw new ArgumentException("Invalid value for wind direction type");
    }
}