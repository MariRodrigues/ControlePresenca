using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Data.Interceptors;
using Microsoft.EntityFrameworkCore;

namespace ContrrolePresenca.Test.Infra.Shared;

public static class DbFactory
{
    
    //public static AppDbContext CreateAppDbContext()
    //{
    //    var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>()
    //        .UseSqlServer("server=localhost;database=controlePresencaDb;user=root;password=root").Options;

        
    //    var interceptor = new AuditSaveChangesInterceptor();
    //    var multiTenantInterceptor = new MultiTenantSaveChangesInterceptor();

    //    return new AppDbContext(optionsBuilder, interceptor);
    //}
}
