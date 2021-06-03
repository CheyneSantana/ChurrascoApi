using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChurrascoApi.Models
{
    public class IntegranteChurrascoModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        public string Nome { get; set; }
        public decimal Valor { get; set; }
        [BsonRepresentation(BsonType.ObjectId)]
        public string ChurrascoId { get; set; }
    }
}
