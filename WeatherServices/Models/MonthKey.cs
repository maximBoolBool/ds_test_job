namespace WeatherServices.Models;

/// <summary>
///     Модель для групировки дней по месяцам
/// </summary>
public class MonthKey : IComparable<MonthKey>
{
    #region Fields

    /// <summary>
    ///     Год
    /// </summary>
    public int Year { get; set; }
    
    /// <summary>
    ///     Месяц
    /// </summary>
    public int Month { get; set; }

    #endregion

    #region .ctor

    /// .ctor
    public MonthKey(int year, int month)
    {
        Year = year;
        Month = month;
    }

    /// .ctor
    public MonthKey(DateOnly date)
    {
        Year = date.Year;
        Month = date.Month;
    }
    
    #endregion
    
    public int CompareTo(MonthKey? other)
    {
        if (other == null)
        {
            return 1;
        }

        int yearComparison = Year.CompareTo(other.Year);
        if (yearComparison != 0)
        {
            return yearComparison;
        }

        return Month.CompareTo(other.Month);
    }
}