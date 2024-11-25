using ControlePresenca.Application.Response;
using MediatR;

namespace ControlePresenca.Application.Commands.Alunos;

public class CreateAlunoCommand : IRequest<ResponseApi>
{
    public string Nome { get; set; }
    public int ClasseId { get; set; }
}
