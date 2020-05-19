using Angular.Aplicacao.DTO.Usuarios;
using Angular.Aplicacao.Interfaces.Usuarios;
using Angular.Dominio.Entidades.Usuarios;
using Angular.Dominio.Interfaces.Repositorios.Usuarios;
using AutoMapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Angular.Aplicacao.Servicos.Usuarios
{
    public class AplicacaoUsuario : ServicoBase<Usuario>, IAplicacaoUsuario
    {
        readonly IMapper _mapper;

        public AplicacaoUsuario(IMapper mapper, IRepositorioUsuario repositorioUsuario) : base(repositorioUsuario) 
        {
            _mapper = mapper;
        }

        public void InsertOne(UsuarioDTO usuarioDTO)
        {
            InsertOne(_mapper.Map<Usuario>(usuarioDTO));
        }

        public void ReplaceOne(UsuarioDTO usuarioDTO)
        {
            ReplaceOne(_mapper.Map<Usuario>(usuarioDTO));
        }

        public async Task<UserForDetailedDTO> GetUser(string id)
        {
            return _mapper.Map<UserForDetailedDTO>(await FindByIdAsync(id));
        }

        public IList<UserForListDTO> GetUsers()
        {
            return _mapper.Map<IList<UserForListDTO>>(AsQueryable());
        }
    }
}
