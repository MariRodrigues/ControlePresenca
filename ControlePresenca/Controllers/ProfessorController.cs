using ControlePresenca.Application.Commands.Professores;
using ControlePresenca.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("api/professor")]
    public class ProfessorController(
        IProfessorRepository repository) : ControllerBase
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

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os professores",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GetTeachers([FromServices] IMediator mediator)
        {
            var response = repository.GetAll();
            return Ok(response);
        }
    }
}
