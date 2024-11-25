using ControlePresenca.Application.Response;
using MediatR;

namespace ControlePresenca.Application.Commands.Presencas;

public class CreatePresencaCommand : IRequest<ResponseApi>
{
    public int AlunoId { get; set; }
    public int RelatorioId { get; set; }
}
