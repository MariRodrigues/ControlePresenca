using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface IClasseRepository
    {
        Classe Cadastrar(Classe classe);
        Classe Editar(Classe classe);
        void Deletar(Classe classe);
        Task<Classe> GetById(int id);
    }
}
