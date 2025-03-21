using ControlePresenca.Domain.Entities;
using ContrrolePresenca.Test.Infra.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ContrrolePresenca.Test.Infra.Repositories
{
    public class AlunoRepositoryTests
    {
        [Fact(DisplayName = "Deve ser possível criar um aluno no banco")]
        public async Task Cadastra_Aluno_E_Busca_Por_ID()
        {
            // Arrange
            Aluno aluno = new() { Id = 97975, Nome = "Mariana Teste", ClasseId = 1 };
            DbAlunoFactory.Create(aluno);

            // Act
            var alunoAddedd = await DbAlunoFactory.GetById(aluno.Id);

            // Assert
            Assert.NotNull(alunoAddedd);

            DbAlunoFactory.Deletar(alunoAddedd);
        }
    }
}
