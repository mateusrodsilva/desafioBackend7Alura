using System.Text;
using desafioBackend7Alura.Controllers;
using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;
using desafioBackend7Alura.Responses.Depoimentos;
using desafioBackend7Alura.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Moq;
using Xunit;

namespace desafioBackend7Alura.Tests.Controllers;

public class DepoimentoControllerTests
{
    private readonly Mock<IDepoimentoService> _depoimentoService = new();
    private readonly Mock<ILogger<DepoimentosController>> _logger = new();


    [Fact]
    public void AoEnviarRequisicaoCriarValida_RetornaraStatusCode201()
    {
        //Arrange
        var controller = new DepoimentosController(_logger.Object, _depoimentoService.Object);
        
        var obj = new CriarDepoimentoRequest
        {
            NomePessoa = "Mateus",
            Depoimento = "Viajei para Campos do Jordão em Julho e foi incível.",
            Foto = new FormFile(new MemoryStream(Encoding.UTF8.GetBytes("Fake content")), 0, 3, "Foto", "minhaImagem.jpg")
        };
        
        _depoimentoService.Setup(ds => ds.Criar(It.IsAny<CriarDepoimentoRequest>()))
            .Returns(new Depoimento(obj));
        
        //Act
        var resultado = controller.Criar(obj) as CreatedResult;
        
        //Assert
        Assert.Equal(StatusCodes.Status201Created, resultado!.StatusCode);
    }
    
    [Fact]
    public void AoEnviarRequisicaoCriarInvalida_RetornaraStatusCode400()
    {
        //Arrange
        var controller = new DepoimentosController(_logger.Object, _depoimentoService.Object);
        
        var obj = new CriarDepoimentoRequest
        {
            NomePessoa = "Mateus",
            Depoimento = "Viajei para Campos do Jordão em Julho e foi incível.",
            Foto = null
        };
        
        _depoimentoService.Setup(ds => ds.Criar(It.IsAny<CriarDepoimentoRequest>()))
            .Throws(new ArgumentNullException());
        
        //Act
        var resultado = controller.Criar(obj) as BadRequestObjectResult;
        
        //Assert
        Assert.Equal(StatusCodes.Status400BadRequest, resultado!.StatusCode);
    }
    
    [Fact]
    public void AoEnviarRequisicaoBuscarPorIdValida_RetornaraStatusCode200()
    {
        //Arrange
        var controller = new DepoimentosController(_logger.Object, _depoimentoService.Object);
        
        _depoimentoService.Setup(ds => ds.BuscarPorId(It.IsAny<Guid>()))
            .Returns(new DepoimentoResponse {Nome = "Mateus", Depoimento = "Fake content", Foto = new MemoryStream(Encoding.UTF8.GetBytes("Fake content")).ToArray()});
        
        //Act
        var resultado = controller.BuscarPorId(Guid.NewGuid()) as OkObjectResult;
        
        //Assert
        Assert.Equal(StatusCodes.Status200OK, resultado!.StatusCode);
    }
    
    [Fact]
    public void AoEnviarRequisicaoBuscarPorIdNaoExistente_RetornaraStatusCode404()
    {
        //Arrange
        var controller = new DepoimentosController(_logger.Object, _depoimentoService.Object);
        
        _depoimentoService.Setup(ds => ds.BuscarPorId(It.IsAny<Guid>()))
            .Throws(new NullReferenceException());
        
        //Act
        var resultado = controller.BuscarPorId(Guid.NewGuid()) as NotFoundResult;
        
        //Assert
        Assert.Equal(StatusCodes.Status404NotFound, resultado!.StatusCode);
    }
    
    [Fact]
    public void AoEnviarRequisicaoExcluirNaoExistente_RetornaraStatusCode204()
    {
        //Arrange
        var controller = new DepoimentosController(_logger.Object, _depoimentoService.Object);

        _depoimentoService.Setup(ds => ds.Excluir(It.IsAny<Guid>()));
        
        //Act
        var resultado = controller.Excluir(Guid.NewGuid()) as NoContentResult;
        
        //Assert
        Assert.Equal(StatusCodes.Status204NoContent, resultado!.StatusCode);
    }
    
    [Fact]
    public void AoEnviarRequisicaoExcluirNaoExistente_RetornaraStatusCode404()
    {
        //Arrange
        var controller = new DepoimentosController(_logger.Object, _depoimentoService.Object);
        
        _depoimentoService.Setup(ds => ds.Excluir(It.IsAny<Guid>()))
            .Throws(new NullReferenceException());
        
        //Act
        var resultado = controller.Excluir(Guid.NewGuid()) as NotFoundResult;
        
        //Assert
        Assert.Equal(StatusCodes.Status404NotFound, resultado!.StatusCode);
    }
}