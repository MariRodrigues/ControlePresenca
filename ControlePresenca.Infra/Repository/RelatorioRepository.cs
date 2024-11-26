using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class RelatorioRepository(AppDbContext context) : IRelatorioRepository
{
    public async Task<Relatorio> AddAsync(Relatorio relatorio)
    {
        await context.Relatorios.AddAsync(relatorio);
        await context.SaveChangesAsync();
        return relatorio;
    }

    public async Task<Relatorio> GetByIdAsync(int id)
    {
        return await context.Relatorios.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> EditAsync(Relatorio relatorio)
    {
        try
        {
            context.Relatorios.Update(relatorio);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
}

public interface IRelatorioRepository
{
    Task<Relatorio> AddAsync(Relatorio relatorio);
    Task<Relatorio> GetByIdAsync(int id);
    Task<bool> EditAsync(Relatorio relatorio);
}
