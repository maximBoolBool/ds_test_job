using AutoMapper;
using WeatherEntities.Entities;
using WeatherServices.Models;

namespace WeatherServices.Mappers;

/// <summary>
///     Маппер для WeatherService
/// </summary>
public class WeatherMapperProfile : Profile
{
    public WeatherMapperProfile()
    {
        CreateMap<WeatherTrackDto, WeatherTrackEntity>()
            .ForMember(dst => dst.Id, opt => opt.MapFrom(src => src.Id))
            .ForMember(dst => dst.Date, opt => opt.MapFrom(src => src.Date))
            .ForMember(dst => dst.Time, opt => opt.MapFrom(src => src.Time))
            .ForMember(dst => dst.Temperature, opt => opt.MapFrom(src => src.Temperature))
            .ForMember(dst => dst.RelativeHumidity, opt => opt.MapFrom(src => src.RelativeHumidity))
            .ForMember(dst => dst.DewPointTemperature, opt => opt.MapFrom(src => src.DewPointTemperature))
            .ForMember(dst => dst.PressureOfMercuryColumn, opt => opt.MapFrom(src => src.PressureOfMercuryColumn))
            .ForMember(dst => dst.WindType, opt => opt.MapFrom(src => src.WindType))
            .ForMember(dst => dst.WindSpeed, opt => opt.MapFrom(src => src.WindSpeed))
            .ForMember(dst => dst.VVMeasureMeasurement, opt => opt.MapFrom(src => src.VVMeasureMeasurement))
            .ForMember(dst => dst.CloudCover, opt => opt.MapFrom(src => src.CloudCover))
            .ForMember(dst => dst.Height, opt => opt.MapFrom(src => src.Height))
            .ForMember(dst => dst.VisibilityVariable, opt => opt.MapFrom(src => src.VisibilityVariable))
            .ForMember(dst => dst.WeatherPhenomena, opt => opt.MapFrom(src => src.WeatherPhenomena))
            .ForMember(dst => dst.FileId, opt => opt.Ignore())
            .ReverseMap();
    }
}