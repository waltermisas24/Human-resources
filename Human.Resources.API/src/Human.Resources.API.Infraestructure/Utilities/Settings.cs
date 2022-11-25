using MongoDB.Driver;

namespace Human.Resources.API.Infraestructure.Utilities
{
    public class Settings
    {
        public SqlSettings SqlSettings { get; set; }
        public MongoSettings MongoDBSetting { get; set; }
    }
}
