using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using System.Collections.Generic;
using System.Linq;

namespace ControlePresenca.Infra.Repository;

public class AlunoRepository(AppDbContext context) : IAlunoRepository
{
    public Aluno Cadastrar(Aluno aluno)
    {
        context.Alunos.Add(aluno);
        context.SaveChanges();
        return aluno;
    }

    public void Deletar(Aluno aluno)
    {
        context.Alunos.Remove(aluno);
        context.SaveChanges();
    }

    public Aluno GetById(int id)
        => context.Alunos.FirstOrDefault(a => a.Id == id);

    public IEnumerable<Aluno> GetAllByRelatory(int ClasseId)
        => context.Alunos.Where(a => a.ClasseId == ClasseId).ToList();
}

public interface IAlunoRepository
{
    Aluno Cadastrar(Aluno aluno);
    public Aluno GetById(int id);
    IEnumerable<Aluno> GetAllByRelatory(int ClasseId);
}
