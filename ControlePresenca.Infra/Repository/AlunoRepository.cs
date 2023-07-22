using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Infra.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AppDbContext _context;

        public AlunoRepository(AppDbContext context)
        {
            _context = context;
        }

        public Aluno Cadastrar(Aluno aluno)
        {
            _context.Alunos.Add(aluno);
            _context.SaveChanges();
            return aluno;
        }

        public void Deletar(Aluno aluno)
        {
            _context.Alunos.Remove(aluno);
            _context.SaveChanges();
        }

        public Aluno GetById(int id)
        {
            return _context.Alunos.FirstOrDefault(a => a.Id == id);
        }

        public IEnumerable<Aluno> GetAllByRelatory(int ClasseId)
        {
            return _context.Alunos.Where(a => a.ClasseId == ClasseId).ToList();
        }
    }
}
