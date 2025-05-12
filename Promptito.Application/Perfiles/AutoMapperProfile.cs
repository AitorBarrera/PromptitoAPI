using AutoMapper;
using Promptito.Application.DTO;
using Promptito.Application.DTO_Post;
using Promptito.Domain.Modelos;

namespace Promptito.Application.Perfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Prompt, Prompt>();
            CreateMap<Llm, Llm>();
            CreateMap<OpcionParametro, OpcionParametro>();
            CreateMap<Parametro, Parametro>();
            CreateMap<PromptVariante, PromptVariante>();
            CreateMap<Tematica, Tematica>();
            CreateMap<Usuario, Usuario>();

            CreateMap<Prompt, PromptDTO>();
            CreateMap<Llm, LlmDTO>();
            CreateMap<OpcionParametro, OpcionParametroDTO>();
            CreateMap<Parametro, ParametroDTO>();
            CreateMap<PromptVariante, PromptVarianteDTO>();
            CreateMap<Tematica, TematicaDTO>();
            CreateMap<Usuario, UsuarioDTO>();


            CreateMap<PromptDTO, Prompt>();
            CreateMap<LlmDTO, Llm>();
            CreateMap<OpcionParametroDTO, OpcionParametro>();
            CreateMap<ParametroDTO, Parametro>();
            CreateMap<PromptVarianteDTO, PromptVariante>();
            CreateMap<TematicaDTO, Tematica>();
            CreateMap<UsuarioDTO, Usuario>();
        }
    }
}
