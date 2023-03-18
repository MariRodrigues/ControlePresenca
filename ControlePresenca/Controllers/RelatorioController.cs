using ControlePresenca.Application.Commands.Relatorio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateRelatorioCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }
    }
}
