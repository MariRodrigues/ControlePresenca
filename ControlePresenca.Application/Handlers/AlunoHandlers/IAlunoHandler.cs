using ControlePresenca.Application.Commands.Aluno;
using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.AlunoHandlers
{
    public interface IAlunoHandler : IRequestHandler<CreateAlunoCommand, ResponseApi>
    {
    }
}
