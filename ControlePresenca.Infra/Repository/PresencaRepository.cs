using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using System.Data.Entity;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class PresencaRepository(AppDbContext context) : IPresencaRepository
{
    public async Task<Presenca> Cadastrar(Presenca presenca)
    {
        await context.Presencas.AddAsync(presenca);
        await context.SaveChangesAsync();
        return presenca;
    }

    public async Task<Presenca> GetById(int id)
    {
        return await context.Presencas.FirstOrDefaultAsync(p => p.Id == id);
    }

    public async Task<Presenca> GetByAlunoRelatorioId(int alunoId, int relatorioId)
    {
        return await context.Presencas.FirstOrDefaultAsync(p => p.AlunoId == alunoId && p.RelatorioId == relatorioId);
    }
}

public interface IPresencaRepository
{
    Task<Presenca> Cadastrar(Presenca presenca);
    Task<Presenca> GetById(int id);
    Task<Presenca> GetByAlunoRelatorioId(int alunoId, int relatorioId);
}
