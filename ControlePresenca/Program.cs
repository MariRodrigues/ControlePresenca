using ControlePresenca.Configurations;
using ControlePresenca.Infra.Data.Interceptors;
using ControlePresenca.Middlewares;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddServices(builder.Configuration);
builder.Services.AddControlePresencaDbContext();
builder.Services.AddAuthenticationSettings(builder.Configuration);

builder.Services.AddScoped<AuditSaveChangesInterceptor>();
builder.Services.AddScoped<MultiTenantSaveChangesInterceptor>();

builder.Services.AddControllers();

builder.Services.AddTransient<TenantMiddleware>();
builder.Services.AddHttpContextAccessor();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.UseMiddleware<TenantMiddleware>();

app.MapControllers();

//app.Initialize();

app.Run();