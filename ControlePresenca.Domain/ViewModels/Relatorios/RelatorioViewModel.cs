using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.ViewModels.Relatorios
{
    public class RelatorioViewModel
    {
        public int RelatorioId { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public int Biblias { get; set; }
        public double Oferta { get; set; }
        public List<PresencasViewModel> Presencas { get; set; }
    }

    public class PresencasViewModel
    {
        public string Nome { get; set; }
        public bool Presente { get; set;}
    }
}
