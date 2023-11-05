using System.ComponentModel.DataAnnotations;
using desafioBackend7Alura.Requests.Depoimentos;

namespace desafioBackend7Alura.Entities;

public class Depoimento
{
    public Depoimento() { }
    
    public Depoimento(CriarDepoimentoRequest obj)
    {
        Id = Guid.NewGuid();
        NomePessoa = obj.NomePessoa ?? throw new ArgumentNullException(nameof(NomePessoa), "O campo NomePessoa não pode ser vazio.");
        ConteudoDepoimento = obj.Depoimento ?? throw new ArgumentNullException(nameof(obj.Depoimento), "O campo NomePessoa não pode ser vazio.");
        Foto = ToByteArray(obj.Foto!) ?? throw new ArgumentNullException(nameof(Foto), "O campo Foto não pode ser vazio.");
        CriadoEm = DateTime.Now;
    }

    public Guid Id { get; private set; }
    public string NomePessoa { get; private set; }
    [MinLength(10, ErrorMessage = "O conteúdo do depoimento deve ter mais que 10 caracteres")]
    public string ConteudoDepoimento { get; private set; }
    public byte[] Foto { get; private set; }
    public DateTime CriadoEm { get; private set; }


    byte[] ToByteArray(IFormFile foto)
    {
        using var stream = new MemoryStream();
        foto.CopyToAsync(stream);
        return stream.ToArray();
    }
}