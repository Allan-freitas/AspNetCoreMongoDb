using Angular.Dominio.Atributos;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace Angular.Dominio.Entidades.Usuarios
{
    [BsonCollection("Usuario")]
    public class Usuario : EntityBase
    {
        public string Nome { get; set; }

        public string SobreNome { get; set; }

        public string Email { get; set; }

        [BsonConstructor]
        public Usuario(string Id, string Nome, string SobreNome, string Email)
        { 
            this.Nome = Nome;
            this.SobreNome = SobreNome;
            this.Email = Email;
            this.Id = Id;
        }
    }
}
