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
    public class PresencaRepository : IPresencaRepository
    {
        private readonly AppDbContext _context;

        public PresencaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Presenca> Cadastrar (Presenca presenca)
        {
            _context.Presencas.Add(presenca);
            _context.SaveChanges();
            return presenca;
        }

        public async Task<Presenca> GetById(int id)
        {
            return await _context.Presencas.FirstOrDefaultAsync(p => p.Id== id);
        }
    }
}
