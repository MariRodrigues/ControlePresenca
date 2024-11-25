using ControlePresenca.Application.Response;
using MediatR;

namespace ControlePresenca.Application.Commands.Professores;

public class CreateProfessorCommand : IRequest<ResponseApi>
{
    public string Nome { get; set; }
}
