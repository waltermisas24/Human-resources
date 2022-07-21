using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Domain.Interfaces;

namespace Human.Resources.API.Domain.Services
{
    public class WorkerServices : IWorkerServices
    {
        private readonly IWorkerRepository _workerRepository;
        private readonly IWorkerTitleRepository _workerTitleRepository;
        public WorkerServices(IWorkerRepository workerRepository, IWorkerTitleRepository workerTitleRepository)
        {
            _workerRepository = workerRepository;
            _workerTitleRepository = workerTitleRepository;
        }

        public Task<List<WorkerEntity>> GetAll()
        {
            var worker = _workerRepository.GetAll();

            return worker;
        }

        public Task<List<WorkerEntity>> GetActives()
        {
            var worker = _workerRepository.GetActives();

            return worker;
        }

        public Task<WorkerEntity> GetById(int IdWorker)
        {
            var worker = _workerRepository.GetById(IdWorker);

            return worker;
        }

        public async Task<WorkerEntity> Income(WorkerEntity workerEntity)
        {
            workerEntity.WorkTitleInfo.DateOut = null;
            workerEntity.WorkTitleInfo.Reason = null;

            await _workerRepository.Insert(workerEntity);
            await _workerTitleRepository.Insert(workerEntity);

            return workerEntity;
        }
        public async Task<bool> Fired(int id, WorkerFiredEntity workerFireEntity)
        {
            await _workerRepository.Delete(id);

            await _workerTitleRepository.Delete(id, workerFireEntity);

            return true;
        }
    }
}
