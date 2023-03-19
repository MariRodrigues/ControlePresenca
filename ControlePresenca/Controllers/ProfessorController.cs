using ControlePresenca.Application.Commands.Professores;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra professor",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateProfessorCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
