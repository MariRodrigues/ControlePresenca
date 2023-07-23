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
        public string NomeClasse { get; set; }
        public DateTime Data { get; set; }
    }

}
