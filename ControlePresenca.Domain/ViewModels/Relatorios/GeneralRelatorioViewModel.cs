using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.ViewModels.Relatorios;

public class GeneralRelatorioViewModel
{
    public int RelatorioId { get; set; }
    public DateTime Data { get; set; }
    public string Observacao { get; set; }
    public string NomeAluno { get; set; }
    public string NomeProfessor { get; set; }
    public string Presenca { get; set; }
    public string Turma { get; set; }

}
