using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Human.Resources.API.Domain.Entities
{
    public class WorkerEntity
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkerStatus { get; set; }
        public WorkTitleInfoEntity WorkTitleInfo { get; set; }

    }
}
