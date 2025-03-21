using ControlePresenca.Domain.Interfaces;

namespace ControlePresenca.Domain.Entities;

public class Presenca : AuditableEntity, IMultiTenantEntity
{
    public int TenantId { get; set; }
    public virtual Aluno Aluno { get; set; }
    public int AlunoId { get; set; }
    public virtual Relatorio Relatorio { get; set; }
    public int RelatorioId { get; set; }
    public bool Presente { get; set; } = false;

    public virtual Tenant Tenant { get; set; }
}