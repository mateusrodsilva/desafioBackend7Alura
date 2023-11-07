using System.Text;
using AutoMapper;
using desafioBackend7Alura.AutoMapperProfiles;
using desafioBackend7Alura.Data.Repositories.Interfaces;
using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;
using desafioBackend7Alura.Responses.Depoimentos;
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
            Depoimento = "Viajei para Campos do Jordão em Julho e foi incrível.",
            Foto = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake content")), 0, 3, "Foto", "minhaImagem.jpg")
        };
        var depoimentoService = new DepoimentoService(_mapper, _mockedDepoimentoRepository.Object);
        // Act 
        var resultado = depoimentoService.Criar(obj);
        
        //Assert
        Assert.IsType<Guid>(resultado.Id);
    }
    
    [Fact]
    public void DadoQuandoDepoimentoInvalido_MetodoCriarEChamado_RetornaArgumentNullException()
    {
        //Arrange
        var obj = new CriarDepoimentoRequest
        {
            NomePessoa = "Mateus",
            Depoimento = null,
            Foto = null
        };
        var depoimentoService = new DepoimentoService(_mapper, _mockedDepoimentoRepository.Object);
        
        
        //Act + Assert
        Assert.Throws<ArgumentNullException>(() => depoimentoService.Criar(obj));
    }
    
    [Fact]
    public void DadoQuandoIdExistente_MetodoBuscarPorIdEChamado_RetornaDepoimentoResponse()
    {
        //Arrange
        var obj = new CriarDepoimentoRequest
        {
            NomePessoa = "Mateus",
            Depoimento = "Viajei para Campos do Jordão em Julho e foi incrível.",
            Foto = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake content")), 0, 3, "Foto", "minhaImagem.jpg")
        };
        
       var depoimentoService = new DepoimentoService(_mapper, _mockedDepoimentoRepository.Object);
       _mockedDepoimentoRepository.Setup(dr => dr.BuscarPorId(It.IsAny<Guid>()))
           .Returns(new Depoimento(obj));
       
       var resultado = depoimentoService.BuscarPorId(Guid.NewGuid());
       
       //Assert
       Assert.IsType<DepoimentoResponse>(resultado);
       Assert.Equal(obj.Depoimento, resultado.Depoimento);
    }
    
    [Fact]
    public void DadoQuandoIdNaoExistente_MetodoBuscarPorIdEChamado_RetornaNullreferenceException()
    {
        //Arrange
        var obj = new CriarDepoimentoRequest
        {
            NomePessoa = "Mateus",
            Depoimento = "Viajei para Campos do Jordão em Julho e foi incrível.",
            Foto = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake content")), 0, 3, "Foto", "minhaImagem.jpg")
        };
        
        var depoimentoService = new DepoimentoService(_mapper, _mockedDepoimentoRepository.Object);
        _mockedDepoimentoRepository.Setup(dr => dr.BuscarPorId(It.IsAny<Guid>()))
            .Throws(new NullReferenceException());
       
        //Act + Assert
        Assert.Throws<NullReferenceException>(() => depoimentoService.BuscarPorId(Guid.NewGuid()));
    }
    
    [Fact]
    public void DadoQuandoIdExistente_MetodoExcluirEChamado_RetornaDepoimentoResponse()
    {
        //Arrange
        var depoimentoService = new DepoimentoService(_mapper, _mockedDepoimentoRepository.Object);
        _mockedDepoimentoRepository.Setup(dr => dr.Excluir(It.IsAny<Guid>()));

        var id = Guid.NewGuid();
        var resultado = depoimentoService.Excluir(id);
       
        //Assert
        Assert.Equal(id, resultado);
    }
    
    [Fact]
    public void DadoQuandoIdNaoExistente_MetodoExcluirEChamado_RetornaNullReferenceException()
    {
        //Arrange
        var depoimentoService = new DepoimentoService(_mapper, _mockedDepoimentoRepository.Object);
        _mockedDepoimentoRepository.Setup(dr => dr.Excluir(It.IsAny<Guid>()))
            .Throws(new NullReferenceException());

        //Act + Assert
        Assert.Throws<NullReferenceException>(() => depoimentoService.Excluir(Guid.NewGuid()));
    }
}