using Human.Resources.API.Domain.Entities;

namespace Human.Resources.API.Domain.Interfaces
{
    public interface IWorkerTitleRepository
    {
        Task<bool> Insert(WorkerEntity workerEntity);
        Task<bool> Delete(int id, WorkerFiredEntity workerFireEntity);
    }
}
