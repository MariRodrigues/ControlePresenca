﻿using ControlePresenca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class LoginRepository : ILoginRepository
{
    private readonly SignInManager<CustomUsuario> _signInManager;

    public LoginRepository(SignInManager<CustomUsuario> signInManager)
    {
        _signInManager = signInManager;
    }

    public async Task<SignInResult> SignInAsync(string username, string password)
    {
        return await _signInManager.PasswordSignInAsync(username, password, false, false);
    }
}

public interface ILoginRepository
{
    Task<SignInResult> SignInAsync(string username, string password);
}