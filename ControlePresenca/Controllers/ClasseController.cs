using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Domain.Query;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Linq;
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
        public async Task<IActionResult> CadastrarAlunos([FromServices] IMediator mediator, CreateClasseCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os alunos",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> BuscarAlunos()
        {
            var response = await _classeQueries.GetAll();
            return Ok(response);
        }

        [HttpGet("{classeId}")]
        [SwaggerOperation(Summary = "Buscar alunos por Classe",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> BuscarAlunosPorClasse(int classeId, [FromQuery] int pagina, [FromQuery] int quantidadeItens)
        {
            var response = await _classeQueries.GetByClass(classeId, pagina, quantidadeItens);

            if (!response.Any())
                return NotFound("Classe não encontrada");

            return Ok(response);
        }
    }
}
