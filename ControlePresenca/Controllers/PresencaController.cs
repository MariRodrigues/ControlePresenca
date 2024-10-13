using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Application.Commands.Presencas;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("api/presenca")]
    public class PresencaController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra nova presença",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreatePresencaCommand command)
        {
            var response = mediator.Send(command);
            return Ok(response);
        }
    }
}
