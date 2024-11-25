namespace ControlePresenca.Domain.Entities;

public class Presenca
{
    public int Id { get; set; }
    public virtual Aluno Aluno { get; set; }
    public int AlunoId { get; set; }
    public virtual Relatorio Relatorio { get; set; }
    public int RelatorioId { get; set; }
    public bool Presente { get; set; } = false;
}
