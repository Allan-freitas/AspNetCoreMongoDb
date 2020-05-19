using Angular.Aplicacao.DTO.Usuarios;
using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Servicos;
using FluentValidation.Results;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Interfaces.Authorities
{
    public interface IAplicacaoAuthorities : IServicoBase<Usuario>
    {
        Task<UsuarioDTO> Register(UsuarioDTO user, string password);

        Task<ValidationResult> Validate(UserForRegisterDTO user);

        Task<UsuarioDTO> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
