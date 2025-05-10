using AutoMapper;
using Promptito.Application.DTO;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Perfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prompt, PromptDTO>()
                .ForMember(dest => dest.PromptVariantes, opt => opt.MapFrom(src => src.PromptVariantes))
                .ForMember(dest => dest.UsuarioCreador, opt => opt.MapFrom(src => src.UsuarioCreador))
                .ForMember(dest => dest.Llms, opt => opt.MapFrom(src => src.Llms))
                .ForMember(dest => dest.Tematicas, opt => opt.MapFrom(src => src.Tematicas))
                .ForMember(dest => dest.Usuarios, opt => opt.MapFrom(src => src.Usuarios));

            CreateMap<Llm, LlmDTO>();
            CreateMap<OpcionParametro, OpcionParametroDTO>();
            CreateMap<Parametro, ParametroDTO>();
            CreateMap<PromptVariante, PromptVarianteDTO>();
            CreateMap<Tematica, TematicaDTO>();
            CreateMap<Usuario, UsuarioDTO>();

            //CreateMap<PromptDTO, Prompt>();
            //CreateMap<LlmDTO, Llm>();
        }
    }
}
