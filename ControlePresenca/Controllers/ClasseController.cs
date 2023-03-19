using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Domain.Query;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ClasseController : ControllerBase
    {
        private readonly IClasseQueries _classeQueries;

        public ClasseController(IClasseQueries classeQueries)
        {
            _classeQueries = classeQueries;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra nova classe",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateClasseCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os alunos",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Buscar()
        {
            var response = await _classeQueries.GetAll();
            return Ok(response);
        }
    }
}
