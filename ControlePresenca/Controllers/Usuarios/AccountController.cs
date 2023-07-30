using ControlePresenca.Application.Requests;
using ControlePresenca.Application.Services;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Services;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using MySqlX.XDevAPI.Common;
using Swashbuckle.AspNetCore.Annotations;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers.Usuarios
{
    [ApiController]
    [Route("[controller]")]
    public class AccountController : ControllerBase
    {
        private readonly LoginService _loginService;
        private readonly IGoogleService _googleService;
        private readonly ITokenService _tokenService;

        public AccountController(LoginService loginService, IGoogleService googleService, ITokenService tokenService)
        {
            _loginService = loginService;
            _googleService = googleService;
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

        [HttpGet("/signin-google-callback")]
        [SwaggerOperation(Summary = "Troca o code pelo token",
            OperationId = "Get")]
        [ProducesResponseType(200)]
        [ProducesResponseType(401)]
        public async Task<IActionResult> SigninGoogle(string code)
        {
            var user = await _googleService.GetToken(code);

            if (user is null)
                return BadRequest("Erro ao gerar token Google");

            var token = _tokenService.CreateToken(user, "user");

            return Ok(token);
        }

    }
}
