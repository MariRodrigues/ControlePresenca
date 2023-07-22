using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.ViewModels.Relatorios;
using ControlePresenca.Infra.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Query
{
    public class RelatorioQueries : IRelatorioQueries
    {
        private readonly MySqlConnection _connection;

        public RelatorioQueries(AppDbContext context)
        {
            _connection = new MySqlConnection(context.Database.GetConnectionString());
        }

        public async Task<IEnumerable<RelatorioViewModel>> GetAllFilter(int? classeId, DateTime? data)
        {
            var queryArgs = new DynamicParameters();

            var query = @"SELECT
                            id as relatorioId, 
                            data 
                            FROM relatorios 
                            WHERE ";

            if (data != null)
            {
                query += " MONTH(data) = @mes AND YEAR(data) = @ano AND ";
                queryArgs.Add("@mes", data.Value.Month);
                queryArgs.Add("@ano", data.Value.Year);
            }

            if (classeId != null)
            {
                query += " classeId = @classeId AND ";
                queryArgs.Add("classeId", classeId);
            }

            if (data == null && classeId == null)
                query = query.Remove(query.LastIndexOf("WHERE"));
            else
                query = query.Remove(query.LastIndexOf("AND"));

            var result = await _connection.QueryAsync<RelatorioViewModel>(query, queryArgs);

            return result;
        }

        public async Task<RelatorioPresencaViewModel> GetRelatorioById (int relatorioId)
        {
            var queryArgs = new DynamicParameters();

            queryArgs.Add("RelatorioId", relatorioId);

            var query = @"SELECT
                            r.Id, 
	                        r.data,
                            r.observacao,
                            r.oferta,
                            r.quantidadebiblias,
                            r.classeId,
                            a.Id as Presencas_AlunoId,
                            p.presente as Presencas_Presente,
                            a.nome as Presencas_Aluno_Nome,
                            (SELECT COUNT(*) FROM presencas WHERE relatorioId = r.id and presente = 1) as Presentes
                            
                            FROM Relatorios r 

                            LEFT JOIN Presencas p on p.relatorioId = r.id
                            LEFT JOIN Alunos a on a.id = p.AlunoId
    
                            WHERE r.id = @RelatorioId ; ";

            var result = await _connection.QueryAsync<dynamic>(query, queryArgs);

            return Slapper.AutoMapper.MapDynamic<RelatorioPresencaViewModel>(result).FirstOrDefault();
        }
    }
}
