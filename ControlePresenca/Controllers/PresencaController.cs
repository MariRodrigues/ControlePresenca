using ControlePresenca.Application.Commands.Classe;
using ControlePresenca.Application.Commands.Presenca;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PresencaController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreatePresencaCommand command)
        {
            var response = mediator.Send(command);
            return Ok(response);
        }
    }
}
