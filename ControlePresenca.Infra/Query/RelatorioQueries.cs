using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.ViewModels.Relatorios;
using ControlePresenca.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient; // Usando SqlClient para SQL Server
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Query
{
    public class RelatorioQueries : IRelatorioQueries
    {
        private readonly SqlConnection _connection; // Troca para SqlConnection

        public RelatorioQueries(AppDbContext context)
        {
            _connection = new SqlConnection(context.Database.GetConnectionString());
        }

        public async Task<IEnumerable<RelatorioViewModel>> GetAllFilter(int? classeId, DateTime? data, int pagina, int quantidadeItens)
        {
            var queryArgs = new DynamicParameters();

            var query = @"SELECT
                            r.id as RelatorioId, 
                            r.data,
                            c.Nome as NomeClasse
                          FROM Relatorios r
                          INNER JOIN Classes c ON c.ID = r.ClasseId
                          WHERE ";

            if (data != null)
            {
                query += " MONTH(r.data) = @mes AND YEAR(r.data) = @ano AND ";
                queryArgs.Add("@mes", data.Value.Month);
                queryArgs.Add("@ano", data.Value.Year);
            }

            if (classeId != null)
            {
                query += " r.ClasseId = @classeId AND ";
                queryArgs.Add("classeId", classeId);
            }

            if (data == null && classeId == null)
                query = query.Remove(query.LastIndexOf("WHERE"));
            else
                query = query.Remove(query.LastIndexOf("AND"));

            // Paginação no SQL Server usando OFFSET e FETCH
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
                            (SELECT COUNT(*) FROM Presencas WHERE relatorioId = r.id AND presente = 1) as Presentes
                          FROM Relatorios r
                          LEFT JOIN Presencas p ON p.relatorioId = r.id
                          LEFT JOIN Alunos a ON a.id = p.AlunoId
                          WHERE r.id = @RelatorioId;";

            var result = await _connection.QueryAsync<dynamic>(query, queryArgs);

            return Slapper.AutoMapper.MapDynamic<RelatorioPresencaViewModel>(result).FirstOrDefault();
        }
    }
}
