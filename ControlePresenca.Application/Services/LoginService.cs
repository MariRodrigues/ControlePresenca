using ControlePresenca.Application.Requests;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Services
{
    public class LoginService
    {
        private readonly ICustomUsuarioRepository _usuarioManager;
        private readonly ILoginRepository _loginRepository;

        public LoginService(ICustomUsuarioRepository usuarioManager, ILoginRepository loginRepository)
        {
            _usuarioManager = usuarioManager;
            _loginRepository = loginRepository;
        }

        public async Task<ResponseApi> LoginUsuario (LoginRequest request)
        {
            var usuarioIdentity = await _usuarioManager.BuscarPorEmail(request.Email);
            
            var result = await _loginRepository.SignIn(usuarioIdentity.UserName, request.Password);

            if (!result.Succeeded)
                return new ResponseApi(false, "Não foi possível fazer login");

            return new ResponseApi(true, "Login realizado com sucesso");
        }
    }
}
