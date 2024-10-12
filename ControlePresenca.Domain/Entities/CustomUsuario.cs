using Microsoft.AspNetCore.Identity;

namespace ControlePresenca.Domain.Entities;

public class CustomUsuario : IdentityUser<int>
{
    public string Name { get; set; }
}
