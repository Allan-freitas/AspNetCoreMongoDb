using Angular.Aplicacao.DTO.Usuarios;
using Angular.Aplicacao.Interfaces.Authorities;
using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Repositorios.Usuarios;
using AutoMapper;
using FluentValidation;
using FluentValidation.Results;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Servicos.Authorities
{
    public class AplicacaoAuthorities : ServicoBase<Usuario>, IAplicacaoAuthorities
    {
        readonly IMapper _mapper;
        readonly IValidator<UserForRegisterDTO> _validator;

        public AplicacaoAuthorities(IRepositorioUsuario repositorioUsuario, IMapper mapper, IValidator<UserForRegisterDTO> validator) : base(repositorioUsuario) 
        {
            _mapper = mapper;
            _validator = validator;
        }

        public async Task<UsuarioDTO> Login(string username, string password)
        {
            UsuarioDTO user = _mapper.Map<UsuarioDTO>(await FindOneAsync(u => u.Username == username));

            if (user == null)
                return null;

            if (!VerifyPasswordHash(password, user.PasswordHash, user.PasswordSalt))
                return null;

            return user;
        }

        public async Task<UsuarioDTO> Register(UsuarioDTO user, string password)
        {
            ValidationResult resultado = _validator.Validate(user);
            byte[] passwordHash, passwordSalt;
            CreatePasswordHash(password, out passwordHash, out passwordSalt);

            user.PasswordHash = passwordHash;
            user.PasswordSalt = passwordSalt;

            await InsertOneAsync(_mapper.Map<Usuario>(user));            

            return user;
        }

        public async Task<ValidationResult> Validate(UserForRegisterDTO user)
        {
            return await _validator.ValidateAsync(user);
        }

        public async Task<bool> UserExists(string username)
        {
            if (await FindOneAsync(u => u.Username == username) != null)
                return true;

            return false;
        }

        private void CreatePasswordHash(string password, out byte[] passwordHash, out byte[] passwordSalt)
        {
            using (HMACSHA512  hmac = new HMACSHA512())
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
