using Human.Resources.API.Domain.Entities;

namespace Human.Resources.API.Domain.Interfaces
{
    public interface IWorkerServices
    {
        Task<List<WorkerEntity>> GetAll();
        Task<List<WorkerEntity>> GetActives();
        Task<WorkerEntity> GetById(int IdWorker);
        Task<WorkerEntity> Income(WorkerEntity workerEntity);
        Task<bool> Fired(int id, WorkerFiredEntity workerFireEntity);
    }
}
