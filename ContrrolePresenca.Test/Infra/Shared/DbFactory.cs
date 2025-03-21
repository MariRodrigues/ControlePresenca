using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Data.Interceptors;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ContrrolePresenca.Test.Infra.Shared
{
    public static class DbFactory
    {
        public static AppDbContext CreateAppDbContext()
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
                .UseSqlServer("server=localhost;database=controlePresencaDb;user=root;password=root").Options;

            var interceptor = new AuditSaveChangesInterceptor();

            return new AppDbContext(optionsBuilder, interceptor);
        }
    }
}
