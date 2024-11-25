using ControlePresenca.Domain.ViewModels.Classes;
using ControlePresenca.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Query;

public class ClasseQueries(AppDbContext context) : IClasseQueries
{
    private readonly SqlConnection _connection = new SqlConnection(context.Database.GetConnectionString());

    public async Task<IEnumerable<ClasseAlunosViewModel>> GetAll()
    {
        var queryArgs = new DynamicParameters();

        var query = @"SELECT
                            c.id as ClasseId, 
                            c.nome,
                            p.nome as Professores_Nome,
                            p.Id as Professores_ProfessorId,
                            a.nome as Alunos_Nome,
                            a.Id as Alunos_AlunoId,
                            (SELECT COUNT(*) FROM alunos WHERE classeId = c.id) as QuantidadeAlunos,
                            (SELECT COUNT(*) FROM relatorios WHERE classeId = c.id) as QuantidadeRelatorios
                          FROM classes c
                          LEFT JOIN professores p ON p.classeId = c.Id
                          LEFT JOIN alunos a ON a.classeId = c.Id";

        var result = await _connection.QueryAsync(query, queryArgs);

        Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ClasseAlunosViewModel), "ClasseId");
        Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ProfessorViewModel), "ProfessorId");
        Slapper.AutoMapper.Configuration.AddIdentifier(typeof(AlunoPresencaViewModel), "AlunoId");

        return Slapper.AutoMapper.MapDynamic<ClasseAlunosViewModel>(result);
    }

    public async Task<IEnumerable<ClasseViewModel>> GetAllClasses()
    {
        var query = @"SELECT 
                            c.Id, 
                            c.Nome,
                            COUNT(a.ClasseId) AS QuantidadeAlunos
                        FROM 
                            Classes c
                        LEFT JOIN 
                            Alunos a ON a.ClasseId = c.Id
                        GROUP BY 
                            c.Id, 
                            c.Nome;";

        return await _connection.QueryAsync<ClasseViewModel>(query);
    }

    public async Task<IEnumerable<ClasseAlunosViewModel>> GetByClass(int classeId, int pagina, int quantidadeItens)
    {
        var queryArgs = new DynamicParameters();

        var query = @"SELECT
                            c.id as ClasseId, 
                            c.nome,
                            p.nome as Professores_Nome,
                            p.Id as Professores_ProfessorId,
                            a.nome as Alunos_Nome,
                            a.Id as Alunos_AlunoId,
                            (SELECT COUNT(*) FROM alunos WHERE classeId = c.id) as QuantidadeAlunos
                          FROM classes c
                          LEFT JOIN professores p ON p.classeId = c.Id
                          LEFT JOIN alunos a ON a.classeId = c.Id
                          WHERE c.Id = @ClasseId
                          ORDER BY c.id
                          OFFSET @Offset ROWS FETCH NEXT @QuantidadeItens ROWS ONLY";

        var offset = (pagina - 1) * quantidadeItens;

        queryArgs.Add("Offset", offset);
        queryArgs.Add("QuantidadeItens", quantidadeItens);
        queryArgs.Add("ClasseId", classeId);

        var result = await _connection.QueryAsync(query, queryArgs);

        Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ClasseAlunosViewModel), "ClasseId");
        Slapper.AutoMapper.Configuration.AddIdentifier(typeof(ProfessorViewModel), "ProfessorId");
        Slapper.AutoMapper.Configuration.AddIdentifier(typeof(AlunoPresencaViewModel), "AlunoId");

        return Slapper.AutoMapper.MapDynamic<ClasseAlunosViewModel>(result);
    }
}

public interface IClasseQueries
{
    Task<IEnumerable<ClasseAlunosViewModel>> GetAll();
    Task<IEnumerable<ClasseAlunosViewModel>> GetByClass(int classeId, int pagina, int quantidadeItens);
    Task<IEnumerable<ClasseViewModel>> GetAllClasses();
}
