using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Data.Interceptors;
using ControlePresenca.Infra.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControlePresenca.Infra.Data;

public class AppDbContext(
    DbContextOptions<AppDbContext> opt,
    AuditSaveChangesInterceptor auditInterceptor,
    MultiTenantSaveChangesInterceptor tenantInterceptor,
    IUserContext userContext)
    : IdentityDbContext<CustomUsuario, IdentityRole<int>, int>(opt)
{
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        base.OnConfiguring(optionsBuilder);
        optionsBuilder.AddInterceptors(auditInterceptor, tenantInterceptor);
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);

        builder.Entity<Aluno>(entity =>
        {
            entity
                  .HasOne(aluno => aluno.Classe)
                  .WithMany(classe => classe.Alunos)
                  .HasForeignKey(aluno => aluno.ClasseId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Tenant)
                  .WithMany(e => e.Alunos)
                  .HasForeignKey(e => e.TenantId)
                  .OnDelete(DeleteBehavior.Restrict);
        });


        builder.Entity<Relatorio>(entity =>
        {
            entity
            .HasOne(relatorio => relatorio.Classe)
            .WithMany(classe => classe.Relatorios)
            .HasForeignKey(relatorio => relatorio.ClasseId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Tenant)
                  .WithMany(e => e.Relatorios)
                  .HasForeignKey(e => e.TenantId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Professor>(entity =>
        {
            entity
            .HasMany(p => p.Relatorios)
            .WithOne(r => r.Professor)
            .HasForeignKey(r => r.ProfessorId);

            entity.HasOne(e => e.Tenant)
                  .WithMany(e => e.Professores)
                  .HasForeignKey(e => e.TenantId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Classe>(entity =>
        {
            entity.HasOne(e => e.Tenant)
                  .WithMany(e => e.Classes)
                  .HasForeignKey(e => e.TenantId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Presenca>(entity =>
        {
            entity
            .HasOne(presenca => presenca.Relatorio)
            .WithMany(relatorio => relatorio.Presencas)
            .HasForeignKey(presenca => presenca.RelatorioId)
            .OnDelete(DeleteBehavior.Restrict);

            entity
            .HasOne(presenca => presenca.Aluno)
            .WithMany(aluno => aluno.Presencas)
            .HasForeignKey(presenca => presenca.AlunoId)
            .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(e => e.Tenant)
                  .WithMany(e => e.Presencas)
                  .HasForeignKey(e => e.TenantId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        builder.Entity<Aluno>().HasQueryFilter(e => e.TenantId == userContext.GetCurrentTenantId());
        builder.Entity<Presenca>().HasQueryFilter(e => e.TenantId == userContext.GetCurrentTenantId());
        builder.Entity<Relatorio>().HasQueryFilter(e => e.TenantId == userContext.GetCurrentTenantId());
        builder.Entity<Classe>().HasQueryFilter(e => e.TenantId == userContext.GetCurrentTenantId());
        builder.Entity<Professor>().HasQueryFilter(e => e.TenantId == userContext.GetCurrentTenantId());
    }

    public DbSet<Classe> Classes { get; set; }
    public DbSet<Aluno> Alunos { get; set; }
    public DbSet<Professor> Professores { get; set; }
    public DbSet<Relatorio> Relatorios { get; set; }
    public DbSet<Presenca> Presencas { get; set; }
}
