using AutoMapper;
using desafioBackend7Alura.Data.Repositories.Interfaces;
using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;
using desafioBackend7Alura.Responses.Depoimentos;
using desafioBackend7Alura.Services.Interfaces;

namespace desafioBackend7Alura.Services;

public class DepoimentoService : IDepoimentoService
{
    private readonly IMapper _mapper;
    private readonly IDepoimentoRepository _depoimentoRepository;

    public DepoimentoService(IMapper mapper, IDepoimentoRepository depoimentoRepository)
    {
        _mapper = mapper;
        _depoimentoRepository = depoimentoRepository;
    }

    public Depoimento Criar(CriarDepoimentoRequest obj)
    {
        var depoimentoEntidade = _mapper.Map<CriarDepoimentoRequest, Depoimento>(obj);

        _depoimentoRepository.Criar(depoimentoEntidade);

        return depoimentoEntidade;
    }

    public DepoimentoResponse BuscarPorId(Guid id)
    {
        return _mapper.Map<Depoimento, DepoimentoResponse>(_depoimentoRepository.BuscarPorId(id));
    }

    public Guid Excluir(Guid id)
    {
        _depoimentoRepository.Excluir(id);
        return id;
    }
}