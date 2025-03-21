using ControlePresenca.Application.Commands.Usuarios;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers.Usuarios
{
    [ApiController]
    [Route("api/usuario")]
    [Authorize]
    public class UsuariosController(IMediator mediator) : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra usuário",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioCommand userDto)
        {
            return Ok(await mediator.Send(userDto));
        }
    }
}
