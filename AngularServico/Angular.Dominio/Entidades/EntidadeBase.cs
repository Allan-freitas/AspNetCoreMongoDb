using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Angular.Dominio.Entidades
{
    public class EntidadeBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }

        [BsonDateTimeOptions(Kind = DateTimeKind.Local, Representation = BsonType.DateTime)]
        public DateTime DataCadastro => DateTime.Now;
    }
}
