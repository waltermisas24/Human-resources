using Human.Resources.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Interfaces
{
    public interface IWorkerRepository
    {
        Task<List<WorkerEntity>> GetAll();
        Task<List<WorkerEntity>> GetActives();
        Task<WorkerEntity> GetById(int IdWorker);
        Task<WorkerEntity> Insert(WorkerEntity workerEntity);
        Task<bool> Delete(int workerId);
    }
}
