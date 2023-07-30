using ControlePresenca.Application.Commands.Alunos;
using ControlePresenca.Domain.Query;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Polly;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoQueries _alunoQueries;

        public AlunoController(IAlunoQueries alunoQueries)
        {
            _alunoQueries = alunoQueries;
        }

        [HttpPost]
        //[Authorize(Policy = "Admin")]
        [SwaggerOperation(Summary = "Cadastra aluno",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateAlunoCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os alunos ou aluno por Id",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromQuery] int? alunoId)
        {
            var response = await _alunoQueries.GetAll(alunoId);
            return Ok(response);
        }
    }
}
