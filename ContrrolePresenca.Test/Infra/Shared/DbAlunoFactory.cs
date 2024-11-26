using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Query;
using ControlePresenca.Infra.Repository;
using System.Threading.Tasks;

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

        public static async void Create (Aluno aluno)
        {
            var contextRepository = CreateAlunoRepositorio(DbFactory.CreateAppDbContext());
            await contextRepository.AddAsync(aluno);
        }
        
        public async static void Deletar (Aluno aluno)
        {
            var contextRepository = CreateAlunoRepositorio(DbFactory.CreateAppDbContext());
            await contextRepository.DeleteAsync(aluno);
        }

        public async static Task<Aluno> GetById (int id)
        {
            var contextRepository = CreateAlunoRepositorio(DbFactory.CreateAppDbContext());
            return await contextRepository.GetByIdAsync(id);
        }
    }
}
