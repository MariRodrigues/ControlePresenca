using ControlePresenca.Domain.Entities;
using Microsoft.AspNet.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace ControlePresenca.Application.Services;

public interface ITokenService
{
    Token CreateToken(CustomUsuario usuario);
}

public class TokenService : ITokenService
{
    public Token CreateToken(CustomUsuario usuario)
    {
        Claim[] direitosUsuario =
        [
            new("userId", usuario.Id.ToString()),
            new("username", usuario.UserName),
            new("email", usuario.Email),
            new("tenantId", usuario.TenantId.ToString()),
            new("name", usuario.Name.ToString())
        ];

        var chave = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")
            );
        var credenciais = new SigningCredentials(chave, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            claims: direitosUsuario,
            signingCredentials: credenciais,
            expires: DateTime.UtcNow.AddHours(1)
        );

        var tokenString = new JwtSecurityTokenHandler().WriteToken(token);
        return new Token(tokenString);
    }
}
