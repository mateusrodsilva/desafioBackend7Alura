using desafioBackend7Alura.Data.Context;
using desafioBackend7Alura.Data.Repositories.Interfaces;
using desafioBackend7Alura.Entities;

namespace desafioBackend7Alura.Data.Repositories;

public class DepoimentoRepository: IDepoimentoRepository
{
    private readonly DatabaseContext _databaseContext;

    public DepoimentoRepository(DatabaseContext databaseContext)
    {
        _databaseContext = databaseContext;
    }

    public void Criar(Depoimento entidade)
    {
        _databaseContext.Depoimentos.Add(entidade);
        _databaseContext.SaveChanges();
    }
}