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
    public class ProfessorRepository : IProfessorRepository
    {
        private readonly AppDbContext _context;

        public ProfessorRepository(AppDbContext context)
        {
            _context = context;
        }

        public Professor Cadastrar(Professor professor)
        {
            _context.Professores.Add(professor);
            _context.SaveChanges();
            return professor;
        }

        public Professor GetById(int id)
        {
            return _context.Professores.FirstOrDefault(p => p.Id == id);
        }
    }
}
