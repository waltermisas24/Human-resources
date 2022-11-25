using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Human.Resources.API.DTOs
{
    public class WorkerDTO
    {
        [BsonId]
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string? Email { get; set; }
        public string PhoneNumber { get; set; }
        public int WorkerStatus { get; set; }
        public string WorkTitle { get; set; }
        public DateTime? DateIn { get; set; }
        public DateTime? DateOut { get; set; }
        public string? ReasonOut { get; set; }
    }
}
