using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;
using desafioBackend7Alura.Responses.Depoimentos;

namespace desafioBackend7Alura.Services.Interfaces;

public interface IDepoimentoService
{
    Depoimento Criar(CriarDepoimentoRequest obj);
    DepoimentoResponse BuscarPorId(Guid id);
    Guid Excluir(Guid id);
}