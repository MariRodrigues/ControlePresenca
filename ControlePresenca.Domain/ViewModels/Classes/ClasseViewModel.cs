using ControlePresenca.Domain.ViewModels.Alunos;
using ControlePresenca.Domain.ViewModels.Relatorios;
using System.Collections.Generic;


namespace ControlePresenca.Domain.ViewModels.Classes
{
    public class ClasseViewModel
    {
        public int ClasseId { get; set; }
        public string Nome { get; set; }
        public int QuantidadeAlunos { get; set; }
        public int QuantidadeRelatorios { get; set; }
        public List<ProfessorViewModel> Professores { get; set; }
        public List<AlunoRelatorioViewModel> Alunos { get; set; }
    }

    public class ProfessorViewModel
    {
        public string Nome { get; set; }
    }
}
