using System;

namespace Angular.Aplicacao.DTO.Usuarios
{
    public class UserForListDTO : DTOBase
    {
        public string Name { get; set; }

        public string Username { get; set; }

        public string Email { get; set; }

        public string Gender { get; set; }

        public int Age { set; get; }

        public string KnownAs { get; set; }

        public DateTime LastActive { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string PhotoUrl { get; set; }
    }
}
