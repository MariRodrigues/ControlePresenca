using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface ILoginRepository
    {
        Task<SignInResult> SignIn(string username, string password);
    }
}
