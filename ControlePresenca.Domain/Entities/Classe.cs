using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControlePresenca.Domain.Entities
{
    public class Classe
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [JsonIgnore]
        public virtual List<Professor> Professores { get; set; }
        [JsonIgnore]
        public virtual List<Aluno> Alunos { get; set; }
        [JsonIgnore]
        public virtual List<Relatorio> Relatorios { get; set; }

    }
}
