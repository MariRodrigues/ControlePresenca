using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Infra.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("api/classe")]
    [Authorize]
    public class ClasseController(
        IClasseQueries classeQueries) : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra nova classe",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> CadastrarAlunos([FromServices] IMediator mediator, CreateClasseCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpDelete("{id}")]
        [SwaggerOperation(Summary = "Deleta classe por Id",
                          OperationId = "Delete")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> DeleteClasse([FromServices] IMediator mediator, int id)
        {
            var response = await mediator.Send(new DeleteClasseCommand(id));
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todas as classes",
                          OperationId = "BuscarTodasClasses")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> BuscarTodasClasses()
        {
            var response = await classeQueries.GetAllClasses();
            return Ok(response);
        }

        [HttpGet("{classeId}/alunos")]
        [SwaggerOperation(Summary = "Get students by class",
                          OperationId = "BuscarAlunosPorClasse")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> BuscarAlunosPorClasse(int classeId, [FromQuery] int pagina = 1, [FromQuery] int quantidadeItens = 10)
        {
            var response = await classeQueries.GetByClass(classeId, pagina, quantidadeItens);

            if (!response.Any())
                return NotFound("Classe não encontrada");

            return Ok(response);
        }
    }
}
