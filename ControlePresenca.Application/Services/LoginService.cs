using ControlePresenca.Application.Requests;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Domain.Services;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Services;

public class LoginService
{
    private readonly ICustomUsuarioRepository _usuarioManager;
    private readonly ILoginRepository _loginRepository;
    private readonly ITokenService _tokenService;
    private readonly SignInManager<CustomUsuario> _signInManager;

    public LoginService(ICustomUsuarioRepository usuarioManager, ILoginRepository loginRepository, SignInManager<CustomUsuario> signInManager, ITokenService tokenService)
    {
        _usuarioManager = usuarioManager;
        _loginRepository = loginRepository;
        _signInManager = signInManager;
        _tokenService = tokenService;
    }

    public async Task<ResponseApi> LoginUsuario (LoginRequest request)
    {
        var usuarioIdentity = await _usuarioManager.BuscarPorEmail(request.Email);
        
        var result = await _loginRepository.SignIn(usuarioIdentity.UserName, request.Password);

        if (!result.Succeeded)
            return new ResponseApi(false, "Não foi possível fazer login");

        Token token = _tokenService.CreateToken(usuarioIdentity);

        return new ResponseApi(true, "Login realizado com sucesso")
        {
            Infos = new { token }
        };
    }
}
