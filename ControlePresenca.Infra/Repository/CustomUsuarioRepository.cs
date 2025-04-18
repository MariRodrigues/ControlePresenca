﻿using ControlePresenca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class CustomUsuarioRepository(UserManager<CustomUsuario> userManager) 
    : ICustomUsuarioRepository
{
    public async Task<IdentityResult> AddAsync(CustomUsuario usuario, string passwordHash)
    {
        var result = await userManager.CreateAsync(usuario, passwordHash);
        return result;
    }

    public async Task<IdentityResult> AddRoleAsync(CustomUsuario usuario, string role)
        => await userManager.AddToRoleAsync(usuario, role);

    public async Task<CustomUsuario> GetByEmailAsync(string email)
        => await userManager.FindByEmailAsync(email);
}

public interface ICustomUsuarioRepository
{
    Task<IdentityResult> AddAsync(CustomUsuario usuario, string passwordHash);
    Task<IdentityResult> AddRoleAsync(CustomUsuario usuario, string role);
    Task<CustomUsuario> GetByEmailAsync(string email);
}
