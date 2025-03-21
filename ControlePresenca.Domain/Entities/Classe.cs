using ControlePresenca.Domain.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControlePresenca.Domain.Entities;

public class Classe : AuditableEntity, IMultiTenantEntity
{
    public int TenantId { get; set; }
    public string Nome { get; set; }
    [JsonIgnore]
    public virtual List<Professor> Professores { get; set; }
    [JsonIgnore]
    public virtual List<Aluno> Alunos { get; set; }
    [JsonIgnore]
    public virtual List<Relatorio> Relatorios { get; set; }
    public virtual Tenant Tenant { get; set; }
}