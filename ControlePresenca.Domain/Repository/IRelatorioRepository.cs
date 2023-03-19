using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface IRelatorioRepository
    {
        Task<Relatorio> Cadastrar(Relatorio relatorio);
        Task<Relatorio> GetById(int id);
        Task<bool> Editar(Relatorio relatorio);
    }
}
