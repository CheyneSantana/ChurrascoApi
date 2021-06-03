using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace ChurrascoApi.Models
{
    public class ChurrascoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public DateTime Data { get; set; }
        public string Descricao { get; set; }
        public string ObservacoesAdicionais { get; set; }
    }
}
