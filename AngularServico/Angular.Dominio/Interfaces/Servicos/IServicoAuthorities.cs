using Angular.Dominio.Entidades.Usuarios;
using System.Threading.Tasks;

namespace Angular.Dominio.Interfaces.Servicos
{
    public interface IServicoAuthorities : IServicoBase<Usuario>
    {
        Task<Usuario> Register(Usuario user, string password);

        Task<Usuario> Login(string username, string password);

        Task<bool> UserExists(string username);
    }
}
