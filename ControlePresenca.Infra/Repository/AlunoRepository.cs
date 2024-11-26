using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class AlunoRepository(AppDbContext context) : IAlunoRepository
{
    public async Task<Aluno> AddAsync(Aluno aluno)
    {
        await context.Alunos.AddAsync(aluno);
        await context.SaveChangesAsync();
        return aluno;
    }

    public async Task DeleteAsync(Aluno aluno)
    {
        context.Alunos.Remove(aluno);
        await context.SaveChangesAsync();
    }

    public async Task<Aluno> GetByIdAsync(int id)
        => await context.Alunos.FirstOrDefaultAsync(a => a.Id == id);

    public async Task<IEnumerable<Aluno>> GetAllByRelatoryAsync(int ClasseId)
        => await context.Alunos.Where(a => a.ClasseId == ClasseId).ToListAsync();
}

public interface IAlunoRepository
{
    Task<Aluno> AddAsync(Aluno aluno);
    Task DeleteAsync(Aluno aluno);
    Task<Aluno> GetByIdAsync(int id);
    Task<IEnumerable<Aluno>> GetAllByRelatoryAsync(int ClasseId);
}
