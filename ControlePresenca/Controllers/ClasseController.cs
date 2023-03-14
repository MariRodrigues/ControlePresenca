using ControlePresenca.Application.Commands.Classe;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClasseController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        public IActionResult Cadastrar([FromServices] IMediator mediator, CreateClasseCommand command)
        {
            var response = mediator.Send(command);
            return Ok(response);
        }
    }
}
