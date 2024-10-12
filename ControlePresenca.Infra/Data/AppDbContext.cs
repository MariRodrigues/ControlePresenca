using ControlePresenca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ControlePresenca.Infra.Data
{
    public class AppDbContext : IdentityDbContext<CustomUsuario, IdentityRole<int>, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Aluno>()
                .HasOne(aluno => aluno.Classe)
                .WithMany(classe => classe.Alunos)
                .HasForeignKey(aluno => aluno.ClasseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Professor>()
                .HasOne(professor => professor.Classe)
                .WithMany(classe => classe.Professores)
                .HasForeignKey(professor => professor.ClasseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Relatorio>()
                .HasOne(relatorio => relatorio.Classe)
                .WithMany(classe => classe.Relatorios)
                .HasForeignKey(relatorio => relatorio.ClasseId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presenca>()
                .HasOne(presenca => presenca.Relatorio)
                .WithMany(relatorio => relatorio.Presencas)
                .HasForeignKey(presenca => presenca.RelatorioId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Presenca>()
                .HasOne(presenca => presenca.Aluno)
                .WithMany(aluno => aluno.Presencas)
                .HasForeignKey(presenca => presenca.AlunoId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        public DbSet<Classe> Classes { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
    }
}
