using ControlePresenca.Domain.Query;
using ControlePresenca.Infra.Data;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace ControlePresenca.Infra.Query
{
    public class ClasseQueries : IClasseQueries
    {
        private readonly MySqlConnection _connection;

        public ClasseQueries(AppDbContext context)
        {
            _connection = new MySqlConnection(context.Database.GetConnectionString());
        }


    }
}
