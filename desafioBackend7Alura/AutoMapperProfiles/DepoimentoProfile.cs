using AutoMapper;
using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;

namespace desafioBackend7Alura.AutoMapperProfiles;

public class DepoimentoProfile : Profile
{
    public DepoimentoProfile()
    {
        CreateMap<CriarDepoimentoRequest, Depoimento>()
            .ConstructUsing(d => new Depoimento(d))
            .IgnoreAllPropertiesWithAnInaccessibleSetter();
        }
}