using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class ProfessorRepository(AppDbContext context) : IProfessorRepository
{
    public async Task<Professor> AddAsync(Professor professor)
    {
        await context.Professores.AddAsync(professor);
        await context.SaveChangesAsync();
        return professor;
    }

    public async Task<Professor> GetByIdAsync(int id)
    {
        return await context.Professores.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<IEnumerable<Professor>> GetAllAsync()
    {
        return await context.Professores.ToListAsync();
    }
}

public interface IProfessorRepository
{
    Task<Professor> AddAsync(Professor professor);
    Task<Professor> GetByIdAsync(int id);
    Task<IEnumerable<Professor>> GetAllAsync();
}
