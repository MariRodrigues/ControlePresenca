using ControlePresenca.Application.Services;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.Repository;
using ControlePresenca.Domain.Services;
using ControlePresenca.Infra.Data;
using ControlePresenca.Infra.Query;
using ControlePresenca.Infra.Repository;
using Google.Protobuf.WellKnownTypes;
using MediatR;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using OpenIddict.Abstractions;
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

            var assembly = AppDomain.CurrentDomain.Load("ControlePresenca.Application");
            services.AddMediatR(assembly);

            services.AddDbContext<AppDbContext>(options =>
            {
                options.UseLazyLoadingProxies();
                options.UseMySQL(Configuration.GetConnectionString("DefaultConnection"));
            });

            services.AddDbContext<UserDbContext>(opts =>
            {
                opts.UseMySQL(Configuration.GetConnectionString("UsuarioConnection"));
                opts.UseOpenIddict();
            });

            services.AddIdentity<CustomUsuario, IdentityRole<int>>()
                .AddEntityFrameworkStores<UserDbContext>()
                .AddDefaultTokenProviders();

            services.AddSwaggerGen(c =>
            {
                c.EnableAnnotations();
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "ControlePresenca", Version = "v1" });
            });

            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).
            AddJwtBearer(token =>
            {
                token.RequireHttpsMetadata = false;
                token.SaveToken = true;
                token.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.UTF8.GetBytes("0asdjas09djsa09djasdjsadajsd09asjd09sajcnzxn")),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                };
            }).AddGoogle(options =>
            {
                // Configuração do Google usando o pacote Microsoft.AspNetCore.Authentication.Google
                options.ClientId = "686934782381-05r2o0rcdkagb151fq39r7u90a96l5ha.apps.googleusercontent.com";
                options.ClientSecret = "sGOCSPX-o9lWgDXmssjPl-4oGCcvuAIGpKxs";
            }); 

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Configure o OpenIddict para usar o Google como provedor de identidade
            services.AddOpenIddict()
                .AddCore(options =>
                {
                    options.UseEntityFrameworkCore()
                           .UseDbContext<UserDbContext>();
                })
                .AddServer(options =>
                {
                    options.SetAuthorizationEndpointUris("/connect/authorize")
                           .SetTokenEndpointUris("/connect/token")
                           .AllowAuthorizationCodeFlow()
                           .AllowRefreshTokenFlow()
                           .RequireProofKeyForCodeExchange();

                    options.RegisterScopes(OpenIddictConstants.Scopes.Profile);
                })
                .AddValidation(options =>
                {
                    options.UseAspNetCore();
                });


            services.AddControllers().AddNewtonsoftJson(options =>
            options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            return services;
        }
    }
}
