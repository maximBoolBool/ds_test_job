using NPOI.SS.UserModel;
using WeatherEntities.Entities;
using WeatherEntities.Enums;

namespace WeatherServices.Extensions;

/// <summary>
///  Хелперы для <see cref="NPOI.XWPF.UserModel.ICell"/>
/// </summary>
public static class RowExtension
{
    private static int[] _cellNumbers = Enumerable.Range(0, 12).ToArray();

    public static WeatherTrackEntity MapToWeather(this IRow row)
    {
        var newEntity = new WeatherTrackEntity()
        {
            Date = row.GetCell(_cellNumbers[0]).GetDateOnlyValue(),
            Time = row.GetCell(_cellNumbers[1]).GetTimeOnlyValue(),
            Temperature = row.GetCell(_cellNumbers[2]).NumericCellValue,
            RelativeHumidity = row.GetCell(_cellNumbers[3]).NumericCellValue,
            DewPointTemperature = row.GetCell(_cellNumbers[4]).NumericCellValue,
            PressureOfMercuryColumn = row.GetCell(_cellNumbers[5]).GetIntValue(),
            WindType = row.GetCell(_cellNumbers[6]).GetWindValue(),
            WindSpeed = row.GetCell(_cellNumbers[7]).GetShortValue(),
            CloudCover = row.GetCell(_cellNumbers[8]).GetShortValue(),
            Height = row.GetCell(_cellNumbers[9]).GetIntValue(),
        };

        if(row.GetCell(_cellNumbers[11]) != null)
        {
            newEntity.WeatherPhenomena = row.GetCell(_cellNumbers[11]).StringCellValue;
        }

        try
        {
            newEntity.VisibilityVariable = row.GetCell(_cellNumbers[10]).GetShortValue();
            newEntity.VVMeasureMeasurement = MeasureMeasurement.Kilometers;
        }
        catch(ArgumentException exp)
        {
            try
            {
                var valueParts = row.GetCell(_cellNumbers[10])
                    .StringCellValue.Split(" ");
                newEntity.VisibilityVariable = short.Parse(valueParts[1]);
                newEntity.VVMeasureMeasurement = MeasureMeasurement.Metrs;
            }
            catch (Exception e)
            {
                throw new ArgumentException("Invalid value for visibility variable");
            }
        }

        return newEntity;
    }
}