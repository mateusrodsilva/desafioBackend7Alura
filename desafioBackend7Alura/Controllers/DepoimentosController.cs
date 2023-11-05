using System.ComponentModel.DataAnnotations;
using System.Net;
using desafioBackend7Alura.Requests.Depoimentos;
using desafioBackend7Alura.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace desafioBackend7Alura.Controllers;

[ApiController]
[Route("[controller]")]
public class DepoimentosController : ControllerBase
{
    private readonly ILogger<DepoimentosController> _logger;
    private readonly IDepoimentoService _depoimentoService;

    public DepoimentosController(ILogger<DepoimentosController> logger, IDepoimentoService depoimentoService)
    {
        _logger = logger;
        _depoimentoService = depoimentoService;
    }

    [HttpPost]
    public IActionResult Criar([FromForm]CriarDepoimentoRequest obj)
    {
        try
        {
            var depoimento = _depoimentoService.Criar(obj);
                
            return Created($"{nameof(BuscarPorId)}/{depoimento.Id}", depoimento.Id);
        }
        catch (ValidationException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (ArgumentNullException ex)
        {
            return BadRequest(ex.Message);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.StackTrace);
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpGet("{id:guid}")]
    public IActionResult BuscarPorId(Guid id)
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.StackTrace);
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpPut]
    public IActionResult Atualizar()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.StackTrace);
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }

    [HttpDelete]
    public IActionResult Excluir()
    {
        try
        {
            throw new NotImplementedException();
        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message, ex.StackTrace);
            return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
        }
    }
}