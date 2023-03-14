using ControlePresenca.Application.Commands.Aluno;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AlunoController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateAlunoCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
