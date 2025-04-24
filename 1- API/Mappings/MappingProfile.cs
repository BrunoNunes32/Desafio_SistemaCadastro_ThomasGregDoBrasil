using AutoMapper;
using Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.DTOs;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.DTOs;
using Desafio_SistemaCadastro_ThomasGergDoBrasil.API.Models;

namespace Desafio_SistemaCadastro_ThomasGergDoBrasil._1__API.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Cliente, ClienteDTO>()
                .ForMember(dest => dest.Logotipo, opt => opt.MapFrom(src => src.Logotipo))
                .ReverseMap()
                .ForMember(dest => dest.Logotipo, opt => opt.Ignore());

            CreateMap<Logradouro, LogradouroDTO>().ReverseMap();
        }
    }
}
