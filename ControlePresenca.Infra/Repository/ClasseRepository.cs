using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository
{
    public class ClasseRepository : IClasseRepository
    {
        private readonly AppDbContext _context;

        public ClasseRepository(AppDbContext context)
        {
            _context = context;
        }

        public Classe Cadastrar(Classe classe)
        {
            _context.Classes.Add(classe);
            _context.SaveChanges();
            return classe;
        }

        public Classe Editar(Classe classe)
        {
            _context.Classes.Update(classe);
            _context.SaveChanges();
            return classe;
        }

        public void Deletar (Classe classe)
        {
            _context.Classes.Remove(classe);
            _context.SaveChanges();
        }

        public async Task<Classe> GetById (int id)
        {
            return await _context.Classes.FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<Classe> GetByName(string name)
        {
            return await _context.Classes.FirstOrDefaultAsync(c => c.Nome.ToLower() == name.ToLower());
        }

    }
}
