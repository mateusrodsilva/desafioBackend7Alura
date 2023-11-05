using desafioBackend7Alura.Entities;

namespace desafioBackend7Alura.Requests.Depoimentos;

public class CriarDepoimentoRequest
{
    public string? NomePessoa { get; set; }
    public string? Depoimento { get; set; }
    public IFormFile? Foto { get; set; }
}