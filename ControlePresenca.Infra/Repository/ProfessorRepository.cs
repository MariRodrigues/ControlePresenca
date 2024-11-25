using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace ControlePresenca.Infra.Repository;

public class ProfessorRepository(AppDbContext context) : IProfessorRepository
{
    public Professor Cadastrar(Professor professor)
    {
        context.Professores.Add(professor);
        context.SaveChanges();
        return professor;
    }

    public Professor GetById(int id)
    {
        return context.Professores.FirstOrDefault(p => p.Id == id);
    }

    public IEnumerable<Professor> GetAll()
    {
        return context.Professores.ToList();
    }
}

public interface IProfessorRepository
{
    Professor Cadastrar(Professor professor);
    Professor GetById(int id);
    IEnumerable<Professor> GetAll();
}
