using Dapper;
using Human.Resources.API.Domain.Entities;
using Human.Resources.API.Domain.Interfaces;
using Human.Resources.API.Infraestructure.Entities;
using Human.Resources.API.Infraestructure.Mapper;
using Human.Resources.API.Infraestructure.Utilities;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using System.Data.SqlClient;

namespace Human.Resources.API.Infraestructure.Repositories
{
    public class WorkerRepository : IWorkerRepository
    {
        private readonly MongoClient _mongoClient;
        private readonly IMongoDatabase _mongoDB;
        private readonly IMongoCollection<WorkerEntity> _mongoCollection;

        public WorkerRepository(IOptions<Settings> settings)
        {
            _mongoClient = new MongoClient(settings.Value.MongoDBSetting.MongoDBConnection);
            _mongoDB = _mongoClient.GetDatabase(settings.Value.MongoDBSetting.MongoDB);
            _mongoCollection = _mongoDB.GetCollection<WorkerEntity>("WorkerData");

        }

        public async Task<List<WorkerEntity>> GetAll()
        {
            var workers = await _mongoCollection.FindAsync(new BsonDocument()).Result.ToListAsync();

            return workers;
        }

        public async Task<List<WorkerEntity>> GetActives()
        {
            throw new NotImplementedException();
        }

        public async Task<WorkerEntity> GetById(string IdWorker)
        {
            var workers = await _mongoCollection.FindAsync(new BsonDocument { { "_id", new ObjectId(IdWorker.ToString()) } }).Result.ToListAsync();

            return workers.First();
        }

        public async Task<WorkerEntity> Insert(WorkerEntity workerEntity)
        {
            await _mongoCollection.InsertOneAsync(workerEntity);

            return workerEntity;
        }

        public async Task<bool> Delete(string workerId)
        {
            var filter = Builders<WorkerEntity>.Filter.Eq(s => s.Id, new ObjectId(workerId.ToString()));
            await _mongoCollection.DeleteOneAsync(filter);

            return true;
        }
    }
}
