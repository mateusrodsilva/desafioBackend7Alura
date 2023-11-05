using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;

namespace desafioBackend7Alura.Services.Interfaces;

public interface IDepoimentoService
{
    Depoimento Criar(CriarDepoimentoRequest obj);
}