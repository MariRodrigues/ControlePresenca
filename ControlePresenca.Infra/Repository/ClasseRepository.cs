using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class ClasseRepository(AppDbContext context) : IClasseRepository
{
    public async Task<Classe> AddAsync(Classe classe)
    {
        await context.Classes.AddAsync(classe);
        await context.SaveChangesAsync();
        return classe;
    }

    public async Task<Classe> EditAsync(Classe classe)
    {
        context.Classes.Update(classe);
        await context.SaveChangesAsync();
        return classe;
    }

    public async Task DeleteAsync(Classe classe)
    {
        context.Classes.Remove(classe);
        await context.SaveChangesAsync();
    }

    public async Task<Classe> GetByIdAsync(int id)
    {
        return await context.Classes.Include(classe => classe.Alunos).
            FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Classe> GetByNameAsync(string name)
        => await context.Classes.FirstOrDefaultAsync(c => c.Nome.ToLower() == name.ToLower());
}

public interface IClasseRepository
{
    Task<Classe> GetByNameAsync(string name);
    Task<Classe> AddAsync(Classe classe);
    Task<Classe> EditAsync(Classe classe);
    Task DeleteAsync(Classe classe);
    Task<Classe> GetByIdAsync(int id);
}
