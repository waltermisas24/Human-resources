using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Human.Resources.API.Infraestructure.Entities
{
    public class WorkerData
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string? WorkerName { get; set; }
        public string? WorkerLastName { get; set; }
        public string? Email { get; set; }
        public string? PhoneNumber { get; set; }
        public int WorkerStatus { get; set; }
        public string WorkerId { get; set; }
        public string? WorkerTitleName { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public string? Reasson { get; set; }
    }
}
