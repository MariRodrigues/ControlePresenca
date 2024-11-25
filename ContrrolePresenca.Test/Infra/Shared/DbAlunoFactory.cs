using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Query;
using ControlePresenca.Infra.Repository;

namespace ContrrolePresenca.Test.Infra.Shared
{
    public static class DbAlunoFactory
    {
        public static AlunoRepository CreateAlunoRepositorio(AppDbContext context)
        {
            return new AlunoRepository(context);
        }

        public static AlunoQueries CreateAlunoQueries(AppDbContext context)
        {
            return new AlunoQueries(context);
        }

        public static void Create (Aluno aluno)
        {
            var contextRepository = CreateAlunoRepositorio(DbFactory.CreateAppDbContext());
            contextRepository.Cadastrar(aluno);
        }
        
        public static void Deletar (Aluno aluno)
        {
            var contextRepository = CreateAlunoRepositorio(DbFactory.CreateAppDbContext());
            contextRepository.Deletar(aluno);
        }

        public static Aluno GetById (int id)
        {
            var contextRepository = CreateAlunoRepositorio(DbFactory.CreateAppDbContext());
            return contextRepository.GetById(id);
        }
    }
}
