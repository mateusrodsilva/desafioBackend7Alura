using System.Text;
using desafioBackend7Alura.Controllers;
using desafioBackend7Alura.Entities;
using desafioBackend7Alura.Requests.Depoimentos;
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
}