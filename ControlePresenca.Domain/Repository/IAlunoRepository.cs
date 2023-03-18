using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface IAlunoRepository
    {
        Aluno Cadastrar(Aluno aluno);
        public Aluno GetById(int id);
        IEnumerable<Aluno> GetAllByRelatory(int ClasseId);
    }
}
