using ControlePresenca.Domain.ViewModels.Alunos;
using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Helpers;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ControlePresenca.Infra.Query;

public class AlunoQueries : IAlunoQueries
{
    private readonly DynamicParameters _queryArgs = new();
    private readonly SqlConnection _connection;

    public AlunoQueries(
        AppDbContext context,
        IUserContext userContext)
    {
        var tenantId = userContext.GetCurrentTenantId().ToString();
        _connection = new(context.Database.GetConnectionString());

        _queryArgs.Add("TenantId", tenantId);
    }

    public async Task<IEnumerable<AlunoViewModel>> GetAll(int? alunoId)
    {
        var query = @"SELECT
                            id, 
                            nome,
                            classeId
                          FROM alunos
                          WHERE tenantId = @TenantId"; 

        if (alunoId is not null)
        {
            query += " AND id = @alunoId";
            _queryArgs.Add("alunoId", alunoId);
        }

        var result = await _connection.QueryAsync<AlunoViewModel>(query, _queryArgs);

        return result;
    }
}

public interface IAlunoQueries
{
    Task<IEnumerable<AlunoViewModel>> GetAll(int? alunoId);
}
