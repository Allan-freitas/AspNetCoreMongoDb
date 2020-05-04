using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Repositorios.Usuarios;
using Angular.Dominio.Interfaces.Servicos;

namespace Angular.Aplicacao.Servicos.Usuarios
{
    public class ServicoUsuario : ServicoBase<Usuario>, IServicoUsuario
    {
        public ServicoUsuario(IRepositorioUsuario repositorioUsuario) : base(repositorioUsuario) { }
    }
}
