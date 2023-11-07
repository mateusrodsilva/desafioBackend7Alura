using AutoMapper;
using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;
using desafioBackend7Alura.Responses.Depoimentos;

namespace desafioBackend7Alura.AutoMapperProfiles;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<CriarDepoimentoRequest, Depoimento>()
            .ConstructUsing(d => new Depoimento(d))
            .IgnoreAllPropertiesWithAnInaccessibleSetter();
        CreateMap<Depoimento, DepoimentoResponse>()
            .ForMember(dest => dest.Depoimento, opt => opt.MapFrom(src => src.ConteudoDepoimento));
        }
}