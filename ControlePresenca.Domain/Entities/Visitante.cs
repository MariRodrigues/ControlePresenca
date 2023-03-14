using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Entities
{
    public class Visitante
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Relatorio Relatorio { get; set; }
        public int RelatorioId { get; set; }
    }
}
