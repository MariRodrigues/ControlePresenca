using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface ILoginRepository
    {
        Task<SignInResult> SignIn(string username, string password);
    }
}
