using ControlePresenca.Domain.ViewModels.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Query
{
    public interface IClasseQueries
    {
        Task<IEnumerable<ClasseAlunosViewModel>> GetAll();
        Task<IEnumerable<ClasseAlunosViewModel>> GetByClass(int classeId, int pagina, int quantidadeItens);
        Task<IEnumerable<ClasseViewModel>> GetAllClasses();
    }
}
