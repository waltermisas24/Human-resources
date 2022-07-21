using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Domain.Interfaces;
using Human.Resources.API.Infraestructure.Utilities;
using Microsoft.Extensions.Options;
using Dapper;
using System.Data.SqlClient;
using Human.Resources.API.Infraestructure.Entities;
using Human.Resources.API.Infraestructure.Mapper;

namespace Human.Resources.API.Infraestructure.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly SqlSettings _sqlSettings;

        public WorkerRepository(IOptions<Settings> settings)
        {
            _sqlSettings = settings.Value.SqlSettings;
        }

        public async Task<List<WorkerEntity>> GetAll()
        {
            IEnumerable<WorkerData> workers;

            string query = "SELECT w.Id, w.WorkerName, w.WorkerLastName, w.Email, w.PhoneNumber, w.WorkerStatus, wt.WorkerTitleName, wt.DateIn, wt.DateOut, wt.Reasson ";
                  query += "FROM Worker w ";
                  query += "INNER JOIN WorkerTitle wt ON wt.WorkerId = w.Id ";

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                workers = await connection.QueryAsync<WorkerData>(query);
            }

            var workerEntity = WorkerMapper.MapToEntity(workers);
            return workerEntity;
        }

        public async Task<List<WorkerEntity>> GetActives()
        {
            IEnumerable<WorkerData> workers;

            string query = "SELECT w.Id, w.WorkerName, w.WorkerLastName, w.Email, w.PhoneNumber, w.WorkerStatus, wt.WorkerTitleName, wt.DateIn, wt.DateOut, wt.Reasson ";
                  query += "FROM Worker w ";
                  query += "INNER JOIN WorkerTitle wt ON wt.WorkerId = w.Id ";
                  query += "WHERE WorkerStatus = 1";

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                workers = await connection.QueryAsync<WorkerData>(query);
            }

            var workerEntity = WorkerMapper.MapToEntity(workers);
            return workerEntity;
        }

        public async Task<WorkerEntity> GetById(int IdWorker)
        {
            IEnumerable<WorkerData> worker;

            string query = "SELECT w.Id, w.WorkerName, w.WorkerLastName, w.Email, w.PhoneNumber, w.WorkerStatus, wt.WorkerTitleName, wt.DateIn, wt.DateOut, wt.Reasson ";
                  query += "FROM Worker w ";
                  query += "INNER JOIN WorkerTitle wt ON wt.WorkerId = w.Id ";
                  query += "WHERE w.Id = " + IdWorker;

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                worker = await connection.QueryAsync<WorkerData>(query);
            }

            var workerEntity = WorkerMapper.MapToEntity(worker);
            return workerEntity.First();
        }

        public async Task<WorkerEntity> Insert(WorkerEntity workerEntity)
        {
            IEnumerable<WorkerData> worker;

            string query = "INSERT INTO Worker ";
                  query += "VALUES('"+ workerEntity.Name +"', '"+ workerEntity.LastName +"', '"+ workerEntity.Email +"', '"+ workerEntity.PhoneNumber +"', "+ 1 +") ";
                  query += "SELECT SCOPE_IDENTITY() AS Id";

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                worker = await connection.QueryAsync<WorkerData>(query);
            }

            workerEntity.Id = worker.First().Id;
            workerEntity.WorkerStatus = 1;

            return workerEntity;
        }

        public async Task<bool> Delete(int workerId)
        {
            string query = "UPDATE Worker ";
                  query += "SET WorkerStatus = " + 0;
                  query += "WHERE Id = " + workerId;

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                await connection.QueryAsync<WorkerData>(query);
            }

            return true;
        }

        
    }
}
