using MongoDB.Driver;
using MongoDB.Bson;
using RotinaDiaria.Models;
using RotinaDiaria.Config;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RotinaDiaria.Repository
{
    public class CompromissoRepository
    {
        private readonly IMongoCollection<Compromisso> _compromissos;

        public CompromissoRepository(MongoDBConfig dbConfig)
        {
            _compromissos = dbConfig.GetCollection<Compromisso>("Compromissos");
        }

        public async Task<List<Compromisso>> GetAllAsync()
        {
            return await _compromissos.Find(_ => true).ToListAsync();
        }

        public async Task<Compromisso> GetByIdAsync(string id)
        {
            var objectId = new ObjectId(id); // Convertendo a string para ObjectId
            return await _compromissos.Find(c => c.Id == objectId).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Compromisso compromisso)
        {
            await _compromissos.InsertOneAsync(compromisso);
        }

        public async Task UpdateAsync(string id, Compromisso compromissoAtualizado)
{
    var objectId = new ObjectId(id); // Convertendo a string para ObjectId

    // Assegure-se de que o campo 'Id' não será alterado na atualização
    compromissoAtualizado.Id = objectId; // Mantendo o Id original

    await _compromissos.ReplaceOneAsync(c => c.Id == objectId, compromissoAtualizado);
}

        public async Task DeleteAsync(string id)
        {
            var objectId = new ObjectId(id); // Convertendo a string para ObjectId
            await _compromissos.DeleteOneAsync(c => c.Id == objectId);
        }
    }
}
