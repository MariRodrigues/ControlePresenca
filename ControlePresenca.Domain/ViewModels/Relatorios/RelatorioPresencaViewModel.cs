using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.ViewModels.Relatorios
{
    public class RelatorioPresencaViewModel
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public double Oferta { get; set; }
        public int Presentes { get; set; }
        public int QuantidadeBiblias { get; set; }
        public int ClasseId { get; set; }
        public List<PresencaViewModel> Presencas { get; set; }
    }

    public class PresencaViewModel
    {
        public int AlunoId { get; set; }
        public bool Presente { get; set; }
        public AlunoRelatorioViewModel Aluno { get; set; }
    }
    public class AlunoRelatorioViewModel
    {
        public string Nome { get; set; }
    }
}
