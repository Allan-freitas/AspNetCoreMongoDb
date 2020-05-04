using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Repositorios.Usuarios;
using Angular.Dominio.MongoDefinicoes;

namespace Angular.Ingra.Data.Repositorio.Usuarios
{
    public class RepositorioUsuario : RepositorioBase<Usuario>, IRepositorioUsuario
    {
        public RepositorioUsuario(IMongoDbDefinicoes mongoDbDefinicoes) : base(mongoDbDefinicoes) { }
    }
}
