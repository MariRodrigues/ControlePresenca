using ControlePresenca.Application.Requests;
using ControlePresenca.Application.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers.Usuarios
{
    [ApiController]
    [Route("api/account")]
    public class AccountController(LoginService loginService) : ControllerBase
    {
        [HttpPost("login")]
        [SwaggerOperation(Summary = "Fazer login do usuário",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LogaUsuario(LoginRequest request)
        {
            var result = await loginService.LoginUsuario(request);
            return Ok(result);
        }
    }
}
