using ControlePresenca.Application.Services;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Domain.Services;
using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Query;
using ControlePresenca.Infra.Repository;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace ControlePresenca.Configurations
{
    public static class ServicesConfiguration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration Configuration)
        {
            services.AddScoped<IClasseRepository, ClasseRepository>();
            services.AddScoped<IClasseQueries, ClasseQueries>();
            services.AddScoped<IAlunoQueries, AlunoQueries>();
            services.AddScoped<IRelatorioQueries, RelatorioQueries>();
            services.AddScoped<IAlunoRepository, AlunoRepository>();
            services.AddScoped<IProfessorRepository, ProfessorRepository>();
            services.AddScoped<IRelatorioRepository, RelatorioRepository>();
            services.AddScoped<IPresencaRepository, PresencaRepository>();
            services.AddScoped<ICustomUsuarioRepository, CustomUsuarioRepository>();
            services.AddScoped<ITokenService, TokenService>();
            services.AddScoped<ILoginRepository, LoginRepository>();
            services.AddScoped<LoginService, LoginService>();

            var assembly = AppDomain.CurrentDomain.Load("ControlePresenca.Application");
            services.AddMediatR(assembly);

            services.AddDbContext<AppDbContext>(opts => opts.UseLazyLoadingProxies()
            .UseMySQL(Configuration.GetConnectionString("DefaultConnection")));

            services.AddDbContext<UserDbContext>(opts => opts.UseMySQL(Configuration.GetConnectionString("UsuarioConnection")));
            services.AddIdentity<CustomUsuario, IdentityRole<int>>().AddEntityFrameworkStores<UserDbContext>();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlePresenca", Version = "v1" });
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return services;
        }
    }
}
