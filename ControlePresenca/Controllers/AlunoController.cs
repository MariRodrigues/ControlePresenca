using ControlePresenca.Application.Commands.Alunos;
using ControlePresenca.Infra.Query;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers;

[ApiController]
[Route("api/aluno")]
public class AlunoController(
    IAlunoQueries alunoQueries) : ControllerBase
{
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
    [SwaggerOperation(Summary = "Busca todos os alunos com filtro",
                      OperationId = "Post")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Cadastrar([FromQuery] int? alunoId)
    {
        var response = await alunoQueries.GetAll(alunoId);
        return Ok(response);
    }
}
