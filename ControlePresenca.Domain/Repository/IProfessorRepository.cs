using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Repository
{
    public interface IProfessorRepository
    {
        Professor Cadastrar(Professor professor);
        Professor GetById(int id);
        IEnumerable<Professor> GetAll();
    }
}
