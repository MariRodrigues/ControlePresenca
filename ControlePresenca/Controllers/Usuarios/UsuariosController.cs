using ControlePresenca.Application.Commands.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class UsuariosController : ControllerBase
    {
        [HttpPost]
        [SwaggerOperation(Summary = "Cadastra usuário",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [AllowAnonymous]
        public async Task<IActionResult> CadastrarUsuario([FromBody] CreateUsuarioCommand userDto)
        {
            // Converto DTO para Command
            // Chamar o Handler

            return Ok();
        }
    }
}
