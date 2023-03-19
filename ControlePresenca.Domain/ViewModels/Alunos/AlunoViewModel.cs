using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.ViewModels.Alunos
{
    public class AlunoViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int ClasseId { get; set; }
    }
}
