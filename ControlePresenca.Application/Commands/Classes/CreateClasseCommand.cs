using ControlePresenca.Application.Response;
using MediatR;

namespace ControlePresenca.Application.Commands.Classes;

public class CreateClasseCommand : IRequest<ResponseApi>
{
    public string Nome { get; set; }
}
