using ControlePresenca.Domain.Interfaces;
using System.Collections.Generic;

namespace ControlePresenca.Domain.Entities;

public class Tenant : AuditableEntity
{
    public string Name { get; set; }

    public IEnumerable<CustomUsuario> Users { get; set; }
    public IEnumerable<Aluno> Alunos { get; set; }
    public IEnumerable<Classe> Classes { get; set; }
    public IEnumerable<Presenca> Presencas { get; set; }
    public IEnumerable<Professor> Professores { get; set; }
    public IEnumerable<Relatorio> Relatorios { get; set; }
}