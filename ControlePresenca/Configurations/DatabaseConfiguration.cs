using ControlePresenca.AppSettings;
using ControlePresenca.Infra.Data;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Threading.Tasks;
using System;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Configurations;

public static class DatabaseConfiguration
{
    public static void AddControlePresencaDbContext(this IServiceCollection service)
    {
        service.AddDbContext<AppDbContext>(static (serviceProvider, optionsBuilder) =>
        {
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();

            optionsBuilder.UseSqlServer(configuration.GetConnectionString(ConnectionStrings.ControlePresencaDataBase));
        });
    }

    public static void Initialize(this IApplicationBuilder app)
    {
        using var serviceScope = app.ApplicationServices.CreateScope();
        using var context = serviceScope.ServiceProvider.GetRequiredService<AppDbContext>();
        using var userManager = serviceScope.ServiceProvider.GetRequiredService<UserManager<CustomUsuario>>();
        using var roleManager = serviceScope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole<int>>>();

        {
            try
            {
                Console.WriteLine("Trying to create and migrate database");
                context.Database.Migrate();
            }
            catch (SqlException exception) when (exception.Number == 1801)
            {
                Console.WriteLine("Database already exists.");
            }

            context.SaveChanges();
        }

        if (userManager.Users.Any())
        {
            return;
        }

        Task.Run(() => CreateUsers(userManager, context)).Wait();
    }

    private static async Task CreateUsers(UserManager<CustomUsuario> userManager, AppDbContext context)
    {
        CustomUsuario admin = new()
        {
            TenantId = 1,
            Name = "Usuario Admin",
            UserName = "admin",
            Email = "admin@hotmail.com",
            NormalizedUserName = "ADMIN",
            NormalizedEmail = "ADMIN@HOTMAIL.COM",
            SecurityStamp = Guid.NewGuid().ToString()
        };

        PasswordHasher<CustomUsuario> passwordHasher = new();
        admin.PasswordHash = passwordHasher.HashPassword(admin, "Senha@123");

        await context.Users.AddRangeAsync(admin);

        await context.SaveChangesAsync();
    }
}
