using ControlePresenca.Domain.ViewModels.Alunos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Query
{
    public interface IAlunoQueries
    {
        Task<IEnumerable<AlunoViewModel>> GetAll(int? alunoId);
    }
}
