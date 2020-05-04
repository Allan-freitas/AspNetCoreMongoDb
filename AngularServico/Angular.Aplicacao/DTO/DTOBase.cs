using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Angular.Aplicacao.DTO
{
    public class DTOBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        public DateTime DataCadastro { get; set; }
    }
}
