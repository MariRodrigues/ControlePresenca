using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Infra.Data;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository
{
    public class CustomUsuarioRepository : ICustomUsuarioRepository
    {
        private readonly UserManager<CustomUsuario> _userManager;

        public CustomUsuarioRepository(UserManager<CustomUsuario> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IdentityResult> Cadastrar(CustomUsuario usuario, string passwordHash)
        {
            var result = await _userManager.CreateAsync(usuario, passwordHash);
            return result;
        }

        public async Task<IdentityResult> AdicionarRole(CustomUsuario usuario, string role)
        {
            return await _userManager.AddToRoleAsync(usuario, role);
        }

        public async Task<CustomUsuario> BuscarPorEmail(string email)
        {
            return await _userManager.FindByEmailAsync(email);
        }
    }
}
