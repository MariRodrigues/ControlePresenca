using ControlePresenca.Application.Commands.Presenca;
using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.PresencaHandlers
{
    public interface IPresencaHandler : IRequestHandler<CreatePresencaCommand, ResponseApi>
    {
    }
}
