using Angular.Aplicacao.DTO.Usuarios;
using Angular.Dominio.Entidades.Usuarios;
using AutoMapper;

namespace Angular.Aplicacao.Mappings
{
    public class AplicacaoMapping : Profile
    {
        public AplicacaoMapping()
        {
            // DTOs
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
        }
    }
}
