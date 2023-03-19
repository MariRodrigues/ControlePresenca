using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.ViewModels.Alunos;
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
    public class AlunoQueries : IAlunoQueries
    {
        private readonly MySqlConnection _connection;

        public AlunoQueries(AppDbContext context)
        {
            _connection = new MySqlConnection(context.Database.GetConnectionString());
        }

        public async Task<IEnumerable<AlunoViewModel>> GetAll(int? alunoId)
        {
            var queryArgs = new DynamicParameters();

            var query = @"SELECT
                            id, 
                            nome,
                            classeId
                            FROM alunos 
                             ";

            if (alunoId is not null)
            {
                query += " WHERE id = @alunoId ";
                queryArgs.Add("alunoId", alunoId);
            }

            var result = await _connection.QueryAsync<AlunoViewModel>(query, queryArgs);

            return result;
        }
    }
}
