using Microsoft.AspNetCore.Mvc;

namespace desafioBackend7Alura.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DepositionsController : ControllerBase
    {
        private readonly ILogger<DepositionsController> _logger;

        public DepositionsController(ILogger<DepositionsController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public IActionResult Get()
        {
            throw new NotImplementedException();
        }
        
        [HttpPut]
        public IActionResult Update()
        {
            throw new NotImplementedException();
        }
        
        [HttpDelete]
        public IActionResult Delete()
        {
            throw new NotImplementedException();
        }
    }
}