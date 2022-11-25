using Human.Resources.API.Domain.Entities;

namespace Human.Resources.API.Domain.Interfaces
{
    public interface IWorkerRepository
    {
        Task<List<WorkerEntity>> GetAll();
        Task<List<WorkerEntity>> GetActives();
        Task<WorkerEntity> GetById(string IdWorker);
        Task<WorkerEntity> Insert(WorkerEntity workerEntity);
        Task<bool> Delete(string workerId);
    }
}
