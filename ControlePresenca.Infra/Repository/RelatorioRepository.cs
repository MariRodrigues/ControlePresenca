using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Repository;

public class RelatorioRepository(AppDbContext context) : IRelatorioRepository
{
    public async Task<Relatorio> Cadastrar(Relatorio relatorio)
    {
        context.Relatorios.Add(relatorio);
        context.SaveChanges();
        return relatorio;
    }

    public async Task<Relatorio> GetById(int id)
    {
        return await context.Relatorios.FirstOrDefaultAsync(r => r.Id == id);
    }

    public async Task<bool> Editar(Relatorio relatorio)
    {
        try
        {
            context.Relatorios.Update(relatorio);
            await context.SaveChangesAsync();
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }
}

public interface IRelatorioRepository
{
    Task<Relatorio> Cadastrar(Relatorio relatorio);
    Task<Relatorio> GetById(int id);
    Task<bool> Editar(Relatorio relatorio);
}
