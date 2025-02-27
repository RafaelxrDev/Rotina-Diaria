using MongoDB.Driver;
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
            return await _compromissos.Find(c => c.Id == id).FirstOrDefaultAsync();
        }

        public async Task CreateAsync(Compromisso compromisso)
        {
            await _compromissos.InsertOneAsync(compromisso);
        }

        public async Task UpdateAsync(string id, Compromisso compromissoAtualizado)
        {
            await _compromissos.ReplaceOneAsync(c => c.Id == id, compromissoAtualizado);
        }

        public async Task DeleteAsync(string id)
        {
            await _compromissos.DeleteOneAsync(c => c.Id == id);
        }
    }
}
