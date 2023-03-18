using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface IPresencaRepository
    {
        Task<Presenca> Cadastrar(Presenca presenca);
        Task<Presenca> GetById(int id);
    }
}
