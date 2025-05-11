using AutoMapper;
using Promptito.Application.DTO;
using Promptito.Application.NavegacionDTO;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Perfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Llm, LlmDTO>();
            CreateMap<OpcionParametro, OpcionParametroDTO>();
            CreateMap<Parametro, ParametroDTO>();
            CreateMap<Prompt, PromptDTO>();
            CreateMap<PromptVariante, PromptVarianteDTO>();
            CreateMap<Tematica, TematicaDTO>();
            CreateMap<Usuario, UsuarioDTO>();



            CreateMap<Llm, LlmMappedDTO>();
            CreateMap<OpcionParametro, OpcionParametroMappedDTO>();
            CreateMap<Parametro, ParametroMappedDTO>();

            CreateMap<Prompt, PromptMappedDTO>()
                .ForMember(dest => dest.PromptVariantes, opt => opt.MapFrom(src => src.PromptVariantes))
                .ForMember(dest => dest.UsuarioCreador, opt => opt.MapFrom(src => src.UsuarioCreador))
                .ForMember(dest => dest.Llms, opt => opt.MapFrom(src => src.Llms))
                .ForMember(dest => dest.Tematicas, opt => opt.MapFrom(src => src.Tematicas))
                .ForMember(dest => dest.EnFavoritosDe, opt => opt.MapFrom(src => src.EnFavoritosDe));

            CreateMap<PromptVariante, PromptVarianteMappedDTO>();
            CreateMap<Tematica, TematicaMappedDTO>();
            CreateMap<Usuario, UsuarioMappedDTO>()
                .ForMember(dest => dest.PromptsCreados, opt => opt.MapFrom(src => src.PromptsCreados));

            //CreateMap<PromptDTO, Prompt>();
            //CreateMap<LlmDTO, Llm>();
        }
    }
}
