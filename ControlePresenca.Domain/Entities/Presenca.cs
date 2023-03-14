using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Entities
{
    public class Presenca
    {
        public int Id { get; set; }
        public virtual Aluno Aluno { get; set; }
        public int AlunoId { get; set; }
        public virtual Relatorio Relatorio { get; set; }
        public int RelatorioId { get; set; }
    }
}
