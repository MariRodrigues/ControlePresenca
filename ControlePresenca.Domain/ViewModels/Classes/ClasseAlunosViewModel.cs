using System.Collections.Generic;

namespace ControlePresenca.Domain.ViewModels.Classes
{
    public class ClasseAlunosViewModel
    {
        public int ClasseId { get; set; }
        public string Nome { get; set; }
        public int QuantidadeAlunos { get; set; }
        public int QuantidadeRelatorios { get; set; }
        public List<ProfessorViewModel> Professores { get; set; }
        public List<AlunoPresencaViewModel> Alunos { get; set; }
    }

    public class ProfessorViewModel
    {
        public int ProfessorId { get; set; }
        public string Nome { get; set; }
    }

    public class AlunoPresencaViewModel
    {
        public int AlunoId { get; set; }
        public string Nome { get; set; }
    }
}
