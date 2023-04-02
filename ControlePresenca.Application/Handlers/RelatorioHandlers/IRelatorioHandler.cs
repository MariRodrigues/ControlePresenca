using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.RelatorioHandlers
{
    public interface IRelatorioHandler : 
        IRequestHandler<CreateRelatorioCommand, ResponseApi>,
        IRequestHandler<UpdateRelatorioCommand, ResponseApi>
    {
    }
}
