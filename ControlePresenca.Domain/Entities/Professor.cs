using ControlePresenca.Domain.Interfaces;
using System.Collections.Generic;

namespace ControlePresenca.Domain.Entities;

public class Professor : AuditableEntity, IMultiTenantEntity
{
    public int TenantId { get; set; }
    public string Nome { get; set; }
    public virtual List<Relatorio> Relatorios { get; set; }

    public virtual Tenant Tenant { get; set; }
}