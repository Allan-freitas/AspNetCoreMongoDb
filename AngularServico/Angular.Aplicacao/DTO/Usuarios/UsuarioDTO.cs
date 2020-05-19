namespace Angular.Aplicacao.DTO.Usuarios
{
    public class UsuarioDTO : DTOBase
    {
        public string Name { get; set; }        

        public string Username { get; set; }

        public byte[] PasswordHash { get; set; }

        public byte[] PasswordSalt { get; set; }

        public string Email { get; set; }
    }
}
