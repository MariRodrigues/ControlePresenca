using ControlePresenca.Application.Requests;
using ControlePresenca.Application.Services;
using ControlePresenca.Domain.Services;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly ITokenService _tokenService;

        public AccountController(LoginService loginService, ITokenService tokenService)
        {
            _loginService = loginService;
            _tokenService = tokenService;
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

        [HttpPost("/connect/authorize")]
        [SwaggerOperation(Summary = "Se autentica com o Google",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> Authorize(LoginRequest request)
        {
            return Ok();
        }
    }
}
