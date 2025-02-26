using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace RotinaDiaria.Config
{
    public class MongoDBConfig
    {
        private readonly IMongoDatebase _datebase; 
        public MongoDBConfig(IOptions<MongoDBSettings> settings)
        {
            var client = new MongoClient(settings.Value.ConnectionString);
            _datebase = client.GetDatebase(settings.Value.DatebaseName);
        }

        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _datebase.GetCollection<T>(name);
        }
    }
    public class MongoDBSettings
    {
        public string ConnectionString {get;set;} = string.Empty;
        public string DatebaseName {get;set;} = string.Empty;
    }
}