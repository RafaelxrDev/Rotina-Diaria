using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RotinaDiaria.Config
{
    public class MongoDBConfig
    {
        private readonly IMongoDatabase _database; 

        public MongoDBConfig(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _database = client.GetDatabase(settings.Value.DatabaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }

    public class MongoDBSettings
    {
        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty; // Nome corrigido
    }
}
