using Angular.Aplicacao.DTO.Usuarios;
using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Servicos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Interfaces.Usuarios
{
    public interface IAplicacaoUsuario : IServicoBase<Usuario>
    {
        void InsertOne(UsuarioDTO usuarioDTO);

        void ReplaceOne(UsuarioDTO usuarioDTO);

        Task<UserForDetailedDTO> GetUser(string id);

        IList<UserForListDTO> GetUsers();
    }
}
