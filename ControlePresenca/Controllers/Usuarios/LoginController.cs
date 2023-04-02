using ControlePresenca.Application.Requests;
using ControlePresenca.Application.Services;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly LoginService _loginService;

        public LoginController(LoginService loginService)
        {
            _loginService = loginService;
        }

        [HttpPost]
        [SwaggerOperation(Summary = "Fazer login do usuário",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> LogaUsuario(LoginRequest request)
        {
            var result = await _loginService.LoginUsuario(request);

            if (!result.Success)
                return Unauthorized(result.Message);

            return Ok(result);
        }
    }
}
