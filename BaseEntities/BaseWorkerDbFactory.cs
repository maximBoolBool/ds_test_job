using Microsoft.Extensions.DependencyInjection;

namespace BaseEntities;

/// Фабрика для бд воркеров
public class BaseWorkerDbFactory<TDbWorker> : IDbWorkerFactory<TDbWorker>
    where TDbWorker : IDbWorker
{
    private readonly IServiceScopeFactory _scopeFactory;

    /// <summary>
    ///     .ctor 
    /// </summary>
    public BaseWorkerDbFactory(IServiceScopeFactory scopeFactory)
    {
        _scopeFactory = scopeFactory;
    }

    /// <summary>
    ///     Создать вокера дял бд
    /// </summary>
    public TDbWorker CreateScopeDataBaseWorker()
     => _scopeFactory.CreateScope().ServiceProvider.GetService<TDbWorker>();
}