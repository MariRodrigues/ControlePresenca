using ControlePresenca.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace ControlePresenca.Infra.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Aluno>()
                .HasOne(aluno => aluno.Classe)
                .WithMany(classe => classe.Alunos)
                .HasForeignKey(aluno => aluno.ClasseId);
            
            modelBuilder.Entity<Professor>()
                .HasOne(professor => professor.Classe)
                .WithMany(classe => classe.Professores)
                .HasForeignKey(professor => professor.ClasseId);

            modelBuilder.Entity<Relatorio>()
                .HasOne(relatorio => relatorio.Classe)
                .WithMany(classe => classe.Relatorios)
                .HasForeignKey(relatorio => relatorio.ClasseId);

            modelBuilder.Entity<Presenca>()
                .HasOne(presenca => presenca.Relatorio)
                .WithMany(relatorio => relatorio.Presencas)
                .HasForeignKey(presenca => presenca.RelatorioId);

            modelBuilder.Entity<Presenca>()
                .HasOne(presenca => presenca.Aluno)
                .WithMany(aluno => aluno.Presencas)
                .HasForeignKey(presenca => presenca.AlunoId);

            modelBuilder.Entity<Visitante>()
                .HasOne(visitante => visitante.Relatorio)
                .WithMany(relatorio => relatorio.Visitantes)
                .HasForeignKey(visitante => visitante.RelatorioId);
        }

        public DbSet<Classe> Classes { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Professor> Professores { get; set; }
        public DbSet<Visitante> Visitantes { get; set; }
        public DbSet<Relatorio> Relatorios { get; set; }
        public DbSet<Presenca> Presencas { get; set; }
    }
}
