using ControlePresenca.Application.Response;
using MediatR;

namespace ControlePresenca.Application.Commands.Classes;

public class DeleteClasseCommand(int id) : IRequest<ResponseApi>
{
    public int Id { get; set; } = id;
}
