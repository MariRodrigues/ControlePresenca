using ControlePresenca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface ICustomUsuarioRepository
    {
        Task<IdentityResult> Cadastrar(CustomUsuario usuario, string passwordHash);
        Task<IdentityResult> AdicionarRole(CustomUsuario usuario, string role);
        Task<CustomUsuario> BuscarPorEmail(string email);
    }
}
