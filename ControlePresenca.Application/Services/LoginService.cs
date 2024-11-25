using ControlePresenca.Application.Requests;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Repository;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Services;

public class LoginService(
    ICustomUsuarioRepository usuarioManager, 
    ILoginRepository loginRepository, 
    ITokenService tokenService)
{
    public async Task<ResponseApi> LoginUsuario (LoginRequest request)
    {
        var usuarioIdentity = await usuarioManager.BuscarPorEmail(request.Email);

        if (usuarioIdentity == null)
            return new ResponseApi(false, "Usuário com esse e-mail não existe");

        var result = await loginRepository.SignIn(usuarioIdentity.UserName, request.Password);

        if (!result.Succeeded)
            return new ResponseApi(false, "Não foi possível fazer login");

        Token token = tokenService.CreateToken(usuarioIdentity);

        return new ResponseApi(true, "Login realizado com sucesso")
        {
            Infos = new { token }
        };
    }
}
