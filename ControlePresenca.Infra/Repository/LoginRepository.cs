using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly SignInManager<CustomUsuario> _signInManager;

        public LoginRepository(SignInManager<CustomUsuario> signInManager)
        {
            _signInManager = signInManager;
        }

        public async Task<SignInResult> SignIn(string username, string password)
        {
            return await _signInManager.PasswordSignInAsync(username, password, false, false);
        }
    }
}
