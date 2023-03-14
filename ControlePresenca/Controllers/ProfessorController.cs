using ControlePresenca.Application.Commands.Professor;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProfessorController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateProfessorCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
