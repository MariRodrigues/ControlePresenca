using ControlePresenca.Domain.ViewModels.Relatorios;
using ControlePresenca.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Query;

public class RelatorioQueries(
    AppDbContext context) : IRelatorioQueries
{
    private readonly SqlConnection _connection = new(context.Database.GetConnectionString());

    public async Task<IEnumerable<RelatorioViewModel>> GetAllFilter(
        int? classeId, DateTime? startDate, DateTime? endDate, int pagina, int quantidadeItens)
    {
        var queryArgs = new DynamicParameters();

        var query = @"SELECT
                           r.id as RelatorioId, 
                           r.data,
                           c.Nome as NomeClasse,
                           Count(p.Id) as QuantidadePresentes

                        FROM Relatorios r
                        INNER JOIN Classes c ON c.ID = r.ClasseId
                        LEFT JOIN Presencas p ON p.RelatorioId = r.Id AND p.Presente = 1

                        WHERE ";

        if (startDate != null && endDate != null)
        {
            query += " r.data >= @startDate AND r.data <= @endDate AND ";
            queryArgs.Add("@startDate", startDate.Value);
            queryArgs.Add("@endDate", endDate.Value);
        }

        if (classeId != null)
        {
            query += " r.ClasseId = @classeId AND ";
            queryArgs.Add("classeId", classeId);
        }

        if (startDate == null && classeId == null)
            query = query.Remove(query.LastIndexOf("WHERE"));
        else
            query = query.Remove(query.LastIndexOf("AND"));

        query += " GROUP BY r.id, r.data, c.nome ";

        if (quantidadeItens != 0 && pagina != 0)
        {
            query += " ORDER BY r.id OFFSET @Offset ROWS FETCH NEXT @QuantidadeItens ROWS ONLY";

            var offset = (pagina - 1) * quantidadeItens;
            queryArgs.Add("Offset", offset);
            queryArgs.Add("QuantidadeItens", quantidadeItens);
        }

        var result = await _connection.QueryAsync<RelatorioViewModel>(query, queryArgs);

        return result;
    }

    public async Task<RelatorioPresencaViewModel> GetRelatorioById(int relatorioId)
    {
        var queryArgs = new DynamicParameters();

        queryArgs.Add("RelatorioId", relatorioId);

        var query = @"SELECT
                            r.Id, 
	                        r.data,
                            r.observacao,
                            r.oferta,
                            r.quantidadebiblias,
                            r.ClasseId,
                            a.Id as Presencas_AlunoId,
                            p.presente as Presencas_Presente,
                            a.nome as Presencas_Aluno_Nome,
                            prof.nome as Professor,
                            (SELECT COUNT(*) FROM Presencas WHERE relatorioId = r.id AND presente = 1) as Presentes
                          FROM Relatorios r
                          LEFT JOIN Presencas p ON p.relatorioId = r.id
                          LEFT JOIN Alunos a ON a.id = p.AlunoId
                          LEFT JOIN Professores prof ON prof.Id = r.ProfessorId
                          WHERE r.id = @RelatorioId;";

        var result = await _connection.QueryAsync<dynamic>(query, queryArgs);

        return Slapper.AutoMapper.MapDynamic<RelatorioPresencaViewModel>(result).FirstOrDefault();
    }

    public async Task<IEnumerable<GeneralRelatorioViewModel>> GetGeneralRelatorio()
    {
        var query = @" SELECT 
                             r.Id as RelatorioId,
                             r.data as Data,
                             r.Observacao as Observacao,
                             a.Nome as NomeAluno,
                             prof.Nome as NomeProfessor,
                             CASE
	                            WHEN p.Presente = 1 THEN 'Presente'
                             ELSE 'Faltou' END as 'Presenca',
                             c.Nome as Turma

                             FROM Relatorios r
                             INNER JOIN Presencas p ON p.RelatorioId = r.Id
                             INNER JOIN Alunos a ON a.Id = p.AlunoId
                             INNER JOIN Professores prof ON prof.Id = r.ProfessorId
                             INNER JOIN Classes c ON c.id = r.ClasseId

                             ORDER BY r.Data DESC";

        var result = await _connection.QueryAsync<GeneralRelatorioViewModel>(query);

        return result;
    }
}

public interface IRelatorioQueries
{
    Task<IEnumerable<RelatorioViewModel>> GetAllFilter(int? classeId, DateTime? startDate, DateTime? endDate, int pagina, int quantidadeItens);
    Task<RelatorioPresencaViewModel> GetRelatorioById(int relatorioId);
    Task<IEnumerable<GeneralRelatorioViewModel>> GetGeneralRelatorio();
}