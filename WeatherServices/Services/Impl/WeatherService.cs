using AutoMapper;
using Microsoft.AspNetCore.Http;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using WeatherEntities;
using WeatherEntities.Entities;
using WeatherServices.Enums;
using WeatherServices.Extensions;
using WeatherServices.Models;
using WeatherServices.Models.Queries;
using WeatherServices.Models.Requests;

namespace WeatherServices.Services.Impl;

/// <inheritdoc cref="IWeatherService"/>
public class WeatherService : IWeatherService
{
    #region Fields

    const int SkipRowsNumber = 4;
    
    private readonly IWeatherDbWorkerFactory _dbFactory;
    private readonly IMapper _mapper;
    
    #endregion
    
    #region .ctor

    public WeatherService(IWeatherDbWorkerFactory dbFactory, IMapper mapper)
    {
        _dbFactory = dbFactory;
        _mapper = mapper;
    }
    
    #endregion

    #region Public Methods

    /// <inheritdoc cref="IWeatherService"/>
    public async Task AddRangeAsync(WeatherAddRequest request, CancellationToken cancellationToken = default)
    {
        using var db = _dbFactory.CreateScopeDataBaseWorker();
        var tasks = request.files.Select(f => ReadIFormFile(f,cancellationToken));
        var entities = await Task.WhenAll(tasks);
        await db.Files.AddRangeAsync(entities, cancellationToken);
        await db.Files.SaveChangesAsync(cancellationToken);
    }

    /// <inheritdoc cref="IWeatherService"/>
    public async Task<PagedListWeatherResponse> ListAsync(DayListQuery query, CancellationToken cancellationToken = default)
    {
        using var db = _dbFactory.CreateScopeDataBaseWorker();

        var entities = await db.Weathers.ListAsync(cancellationToken);

        WeatherTrackDto[] models;
        switch (query.Type)
        {
            case PaginationType.Month:
                var montGroups = entities.GroupBy(e => new { e.Date.Year, e.Date.Month });
                var monthGroup = montGroups
                    .OrderBy(g => g.Key.Year)
                    .ThenBy(g => g.Key.Month)
                    .Skip(query.PageNumber - 1)
                    .FirstOrDefault();
                
                models = _mapper.Map<WeatherTrackDto[]>(monthGroup.ToArray());
                return new PagedListWeatherResponse(models, montGroups.Count(), query.PageNumber, query.Type);

            case PaginationType.Year:
                var yearGroups = entities.GroupBy(e => e.Date.Year);
                var yearGroup = yearGroups.OrderBy(g => g.Key)
                    .Skip(query.PageNumber - 1)
                    .FirstOrDefault();

                models = _mapper.Map<WeatherTrackDto[]>(yearGroup.ToArray());
                return new PagedListWeatherResponse(models, yearGroups.Count(), query.PageNumber, query.Type);

            default:
                throw new NotImplementedException();
        }
    }

    #endregion

    #region PrivateMethods
    
    private async Task<FileEntity> ReadIFormFile(IFormFile form, CancellationToken cancellationToken = default)
    {
        await using var stream = form.OpenReadStream();
        var book = new XSSFWorkbook(stream);
        
        var sheets = book.GetAllSheets();
        var tasks = sheets.Select(s => MapFromSheet(s, cancellationToken: cancellationToken));

        var matrix = await Task.WhenAll(tasks);
        return new()
        {
            Name = form.FileName,
            Weather = matrix.SelectMany(e => e).ToList()
        };
    }
    
    private async Task<IEnumerable<WeatherTrackEntity>> MapFromSheet(
        ISheet sheet,
        CancellationToken cancellationToken = default)
    {
        var entities = new List<WeatherTrackEntity>();
        var rowsCount = sheet.PhysicalNumberOfRows;
        for (var i = SkipRowsNumber; i < rowsCount; i++)
        {
            var newModel = sheet.GetRow(i).MapToWeather();
            entities.Add(newModel);
        }

        return entities;
    }

    #endregion
    
}