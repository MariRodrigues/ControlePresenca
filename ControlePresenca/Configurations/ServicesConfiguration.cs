using ControlePresenca.Application.Services;
using ControlePresenca.AppSettings;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Domain.Services;
using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Query;
using ControlePresenca.Infra.Repository;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System;
using System.Text;

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
            services.AddScoped<IDocumentServices, DocumentServices>();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlePresenca", Version = "v1" });
            });

            var assembly = AppDomain.CurrentDomain.Load("ControlePresenca.Application");
            services
                .AddValidatorsFromAssembly(assembly)
                .AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(assembly));

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers()
                .AddNewtonsoftJson(options =>
                    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return services;
        }

        public static void AddAuthenticationSettings(this IServiceCollection service, IConfiguration configuration)
        {
            var jwtSecret = configuration["Jwt:Secret"];

            service.AddIdentity<CustomUsuario, IdentityRole<int>>()
            .AddEntityFrameworkStores<AppDbContext>()
            .AddDefaultTokenProviders();

            service.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes(jwtSecret!)),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            });
        }
    }
}
