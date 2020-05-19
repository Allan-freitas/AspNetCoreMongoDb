using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Repositorios.Usuarios;
using Angular.Dominio.Interfaces.Servicos;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Servicos.Authorities
{
    public class ServicoAuthorities : ServicoBase<Usuario>, IServicoAuthorities
    {
        public ServicoAuthorities(IRepositorioUsuario repositorioUsuario) : base(repositorioUsuario) { }

        public async Task<Usuario> Login(string username, string password)
        {
            Usuario user = await FindOneAsync(u => u.Username == username);

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<Usuario> Register(Usuario user, string password)
        {
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await InsertOneAsync(user);

            return user;
        }

        public async Task<bool> UserExists(string username)
        {
            if (await FindOneAsync(u => u.Username == username) != null)
                return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512 hmac = new HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        private bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var hmac = new HMACSHA512(passwordSalt))
            {
                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != passwordHash[i]) return false;
                }
            }
            return true;
        }
    }
}
