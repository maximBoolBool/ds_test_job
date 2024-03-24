namespace BaseEntities;

public interface IDbWorkerFactory<TDbWorker>
    where TDbWorker : IDbWorker
{
    TDbWorker CreateScopeDataBaseWorker();
}