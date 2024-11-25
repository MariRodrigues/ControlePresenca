using System.Collections.Generic;

namespace ControlePresenca.Domain.Entities;

public class Professor
{
    public int Id { get; set; }
    public string Nome { get; set; }
    public virtual List<Relatorio> Relatorios { get; set; }
}
