using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControlePresenca.Domain.Entities;

public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual Classe Classe { get; set; }
    public int ClasseId { get; set; }
    [JsonIgnore]
    public virtual List<Presenca> Presencas { get; set; }
}
