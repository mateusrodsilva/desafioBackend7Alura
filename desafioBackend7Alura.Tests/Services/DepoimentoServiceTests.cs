using System.Text;
using AutoMapper;
using desafioBackend7Alura.AutoMapperProfiles;
using desafioBackend7Alura.Data.Repositories.Interfaces;
using desafioBackend7Alura.Requests.Depoimentos;
using desafioBackend7Alura.Services;
using Microsoft.AspNetCore.Http;
using Moq;
using Xunit;

namespace desafioBackend7Alura.Tests.Services;

public class DepoimentoServiceTests
{
    private readonly Mock<IDepoimentoRepository> _mockedDepoimentoRepository = new();
    private readonly IMapper _mapper;
    
    public DepoimentoServiceTests()
    {
        var config = new MapperConfiguration(opt =>
        {
            opt.AddProfile(new DepoimentoProfile());
        });
        _mapper = config.CreateMapper();
    }

    [Fact]
    public void DadoQuandoDepoimentoValido_MetodoCriarEChamado_RetornaEntidadeDepoimento()
    {
        //Arrange
        var obj = new CriarDepoimentoRequest
        {
            NomePessoa = "Mateus",
            Depoimento = "Viajei para Campos do Jordão em Julho e foi incível.",
            Foto = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake content")), 0, 3, "Foto", "minhaImagem.jpg")
        };
        var depoimentoService = new DepoimentoService(_mapper, _mockedDepoimentoRepository.Object);
        // var 
        var resultado = depoimentoService.Criar(obj);
        
        //Assert
        Assert.IsType<Guid>(resultado.Id);
    }
}