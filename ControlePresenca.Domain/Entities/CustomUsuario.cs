using ControlePresenca.Domain.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace ControlePresenca.Domain.Entities;

public class CustomUsuario : IdentityUser<int>, IMultiTenantEntity
{
    public int TenantId { get; set; }
    public string Name { get; set; }

    public virtual Tenant Tenant { get; set; }
}