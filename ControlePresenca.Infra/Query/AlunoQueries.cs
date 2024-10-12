using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.ViewModels.Alunos;
using ControlePresenca.Infra.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Query
{
    public class AlunoQueries : IAlunoQueries
    {
        private readonly SqlConnection _connection; 

        public AlunoQueries(AppDbContext context)
        {
            _connection = new SqlConnection(context.Database.GetConnectionString());
        }

        public async Task<IEnumerable<AlunoViewModel>> GetAll(int? alunoId)
        {
            var queryArgs = new DynamicParameters();

            var query = @"SELECT
                            id, 
                            nome,
                            classeId
                          FROM alunos"; // SQL Server deve suportar essa query sem problemas

            if (alunoId is not null)
            {
                query += " WHERE id = @alunoId";
                queryArgs.Add("alunoId", alunoId);
            }

            var result = await _connection.QueryAsync<AlunoViewModel>(query, queryArgs);

            return result;
        }
    }
}
