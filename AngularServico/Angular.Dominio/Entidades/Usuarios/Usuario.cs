using Angular.Dominio.Atributos;
using Angular.Dominio.Entidades.Photos;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections;
using System.Collections.Generic;

namespace Angular.Dominio.Entidades.Usuarios
{
    [BsonCollection("Usuario")]
    public class Usuario : EntidadeBase
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public DateTime DateOfBirth { set; get; }

        public string KnownAs { get; set; }        

        public DateTime LastActive { get; set; }

        public string Introduction { get; set; }

        public string LookingFor { get; set; }

        public string Interests { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public IList<Photo> Photos { get; set; }

        [BsonConstructor]
        public Usuario(string id, string name, string username, string email, byte[] passwordHash, byte[] passwordSalt)
        { 
            Name = name;
            Username = username;
            Email = email;
            Id = id;
            PasswordHash = passwordHash;
            PasswordSalt = passwordSalt;
        }
    }
}
