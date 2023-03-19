using ControlePresenca.Domain.ViewModels.Relatorios;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Query
{
    public interface IRelatorioQueries
    {
        Task<IEnumerable<RelatorioViewModel>> GetAllFilter(int? classeId, DateTime? data);
        Task<RelatorioPresencaViewModel> GetRelatorioById(int relatorioId);
    }
}
