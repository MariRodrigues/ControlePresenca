using ControlePresenca.Domain.Interfaces;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControlePresenca.Domain.Entities;

public class Aluno : AuditableEntity, IMultiTenantEntity
{
    public int TenantId { get; set; }
    public string Nome { get; set; }
    public virtual Classe Classe { get; set; }
    public int ClasseId { get; set; }
    [JsonIgnore]
    public virtual List<Presenca> Presencas { get; set; }
    public virtual Tenant Tenant { get; set; }
}
