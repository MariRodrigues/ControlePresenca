using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class ClasseRepository(AppDbContext context) : IClasseRepository
{
    public Classe Cadastrar(Classe classe)
    {
        context.Classes.Add(classe);
        context.SaveChanges();
        return classe;
    }

    public Classe Editar(Classe classe)
    {
        context.Classes.Update(classe);
        context.SaveChanges();
        return classe;
    }

    public void Deletar (Classe classe)
    {
        context.Classes.Remove(classe);
        context.SaveChanges();
    }

    public async Task<Classe> GetById (int id)
    {
        return await context.Classes.Include(classe => classe.Alunos).
            FirstOrDefaultAsync(c => c.Id == id);
    }

    public async Task<Classe> GetByName(string name)
        => await context.Classes.FirstOrDefaultAsync(c => c.Nome.ToLower() == name.ToLower());
}

public interface IClasseRepository
{
    Task<Classe> GetByName(string name);
    Classe Cadastrar(Classe classe);
    Classe Editar(Classe classe);
    void Deletar(Classe classe);
    Task<Classe> GetById(int id);
}
