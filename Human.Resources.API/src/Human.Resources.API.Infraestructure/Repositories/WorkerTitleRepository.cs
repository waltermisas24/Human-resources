using Dapper;
using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Domain.Interfaces;
using Human.Resources.API.Infraestructure.Entities;
using Human.Resources.API.Infraestructure.Mapper;
using Human.Resources.API.Infraestructure.Utilities;
using Microsoft.Extensions.Options;
using System.Data.SqlClient;

namespace Human.Resources.API.Infraestructure.Repositories
{
    public class WorkerTitleRepository : IWorkerTitleRepository
    {
        private readonly SqlSettings _sqlSettings;
        public WorkerTitleRepository(IOptions<Settings> settings)
        {
            _sqlSettings = settings.Value.SqlSettings;
        }

        public async Task<bool> Insert(WorkerEntity workerEntity)
        {
            WorkerData workerData = WorkerTitleMapper.MapEntityToData(workerEntity);

            string query = "INSERT INTO WorkerTitle ([WorkerId],[WorkerTitleName],[DateIn],[DateOut],[Reasson]) ";
            query += "VALUES(@WorkerId, @WorkerTitleName, @DateIn, null, null)";

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                await connection.QueryAsync<WorkTitleInfoEntity>(query, workerData);
            }

            return true;
        }

        public async Task<bool> Delete(int id, WorkerFiredEntity workerFireEntity)
        {
            string query = "UPDATE WorkerTitle ";
            query += "SET DateOut = '" + workerFireEntity.DateOut + "', ";
            query += "Reasson = '" + workerFireEntity.ReasonOut + "' ";
            query += "WHERE WorkerId = " + id;

            using (var connection = new SqlConnection(this._sqlSettings.ConnectionStrings))
            {
                await connection.QueryAsync<WorkTitleInfoEntity>(query);
            }

            return true;
        }
    }
}
