using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace RotinaDiaria.Models
{
    public class Compromisso
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)] // Isso converte automaticamente para string
          public ObjectId Id { get; set; }

        public string Nome { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Hora { get; set; } = string.Empty;
        public string Duracao { get; set; } = string.Empty;
    }
}
