using Angular.Aplicacao.DTO.Usuarios;
using Angular.Aplicacao.Mappings.Extensions;
using Angular.Dominio.Entidades.Usuarios;
using AutoMapper;
using System.Linq;

namespace Angular.Aplicacao.Mappings
{
    public class AplicacaoMapping : Profile
    {
        public AplicacaoMapping()
        {
            // DTOs
            CreateMap<UsuarioDTO, Usuario>().ReverseMap();
            CreateMap<UserForRegisterDTO, Usuario>().ReverseMap();
            CreateMap<UsuarioDTO, UserForRegisterDTO>().ReverseMap();
            CreateMap<UserForDetailedDTO, Usuario>();
            CreateMap<Usuario, UserForDetailedDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain)))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
            CreateMap<Usuario, UserForListDTO>()
                .ForMember(dest => dest.PhotoUrl, opt => opt.MapFrom(src => src.Photos.FirstOrDefault(p => p.IsMain)))
                .ForMember(dest => dest.Age, opt => opt.MapFrom(src => src.DateOfBirth.CalculateAge()));
        }
    }
}
