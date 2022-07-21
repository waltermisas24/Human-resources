using Human.Resources.API.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Human.Resources.API.Domain.Interfaces
{
    public interface IWorkerTitleRepository
    {
        Task<bool> Insert(WorkerEntity workerEntity);
        Task<bool> Delete(int id, WorkerFiredEntity workerFireEntity);
    }
}
