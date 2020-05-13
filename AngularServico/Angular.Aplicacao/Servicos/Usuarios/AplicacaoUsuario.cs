using Angular.Aplicacao.DTO.Usuarios;
using Angular.Aplicacao.Interfaces.Usuarios;
using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Servicos;
using AutoMapper;

namespace Angular.Aplicacao.Servicos.Usuarios
{
    public class AplicacaoUsuario : AplicacaoBase<Usuario, UsuarioDTO>, IAplicacaoUsuario
    {
        public AplicacaoUsuario(IMapper mapper, IServicoUsuario servicoUsuario) : base(mapper, servicoUsuario) { }
    }
}
