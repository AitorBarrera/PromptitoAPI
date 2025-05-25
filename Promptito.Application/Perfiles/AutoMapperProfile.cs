using AutoMapper;
using Promptito.Application.DTO;
using Promptito.Application.NavegacionDTO;
using Promptito.Application.DTO_Post;
using Promptito.Domain.Modelos;
using Promptito.Application.DTO_PostConNavegacion;

namespace Promptito.Application.Perfiles
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            //Mappings oara DTOs en Get mothods SIN propiedades de navegacion 
            CreateMap<Llm, LlmDTO>();
            CreateMap<OpcionParametro, OpcionParametroDTO>();
            CreateMap<Parametro, ParametroDTO>();
            CreateMap<Prompt, PromptDTO>();
            CreateMap<PromptVariante, PromptVarianteDTO>();
            CreateMap<Tematica, TematicaDTO>();
            CreateMap<Usuario, UsuarioDTO>();


            //Mappings para DTOs en Get mothods CON propiedades de navegacion 
            CreateMap<Llm, LlmDTONavegacion>();
            CreateMap<OpcionParametro, OpcionParametroDTONavegacion>();
            CreateMap<Parametro, ParametroDTONavegacion>();
            CreateMap<Prompt, PromptDTONavegacion>();
            CreateMap<PromptVariante, PromptVarianteDTONavegacion>();
            CreateMap<Tematica, TematicaDTONavegacion>();
            CreateMap<Usuario, UsuarioDTONavegacion>();


            //Mappings para DTOs de agregacion en los metodos POST y PUT
            CreateMap<PromptDTOPost, Prompt>();
            CreateMap<LlmDTOPost, Llm>();
            CreateMap<OpcionParametroDTOPost, OpcionParametro>();
            CreateMap<ParametroDTOPost, Parametro>();
            CreateMap<PromptVarianteDTOPost, PromptVariante>();
            CreateMap<TematicaDTOPost, Tematica>();
            CreateMap<UsuarioDTOPost, Usuario>();

            CreateMap<PromptDTOPostConNavegacion, Prompt>();
            CreateMap<LlmDTOPostConNavegacion, Llm>();
            CreateMap<OpcionParametroDTOPostConNavegacion, OpcionParametro>();
            CreateMap<ParametroDTOPostConNavegacion, Parametro>();
            CreateMap<PromptVarianteDTOPostConNavegacion, PromptVariante>();
            CreateMap<TematicaDTOPostConNavegacion, Tematica>();
        }
    }
}
