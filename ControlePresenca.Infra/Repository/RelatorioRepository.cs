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
    public class RelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public RelatorioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Relatorio> Cadastrar(Relatorio relatorio)
        {
            _context.Relatorios.Add(relatorio);
            _context.SaveChanges();
            return relatorio;
        }

        public async Task<Relatorio> GetById(int id)
        {
            return await _context.Relatorios.FirstOrDefaultAsync(r => r.Id == id);
        }

        public async Task<bool> Editar(Relatorio relatorio)
        {
            try
            {
                _context.Relatorios.Update(relatorio);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
