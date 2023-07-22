using ControlePresenca.Infra.Data;
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
                .UseMySQL("server=localhost;database=controlePresencaDb;user=root;password=root").Options;

            return new AppDbContext(optionsBuilder);
        }
    }
}
