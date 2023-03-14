using ControlePresenca.Application.Commands.Professor;
using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.ProfessorHandlers
{
    public interface IProfessorHandler : IRequestHandler<CreateProfessorCommand, ResponseApi>
    {
    }
}
