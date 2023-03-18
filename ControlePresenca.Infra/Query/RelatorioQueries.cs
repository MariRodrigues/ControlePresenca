using ControlePresenca.Domain.ViewModels.Relatorios;
using ControlePresenca.Infra.Data;
using Dapper;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Query
{
    public class RelatorioQueries
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
                            r.id AS RelatorioId, 
                            r.observacao, 
                            r.data, 
                            a.nome AS AlunosViewModel_Nome,
                            p.presente as AlunosViewModel_Presente,
                            FROM presencas p
                            INNER JOIN relatorios r ON r.Id = p.relatorioId
                            INNER JOIN alunos a ON a.Id = p.alunoId";

            var result = await _connection.QueryAsync(query, queryArgs);


        }
    }
}
