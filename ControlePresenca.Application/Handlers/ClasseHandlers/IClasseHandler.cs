using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.ClasseHandlers
{
    public interface IClasseHandler : 
        IRequestHandler<CreateClasseCommand, ResponseApi>,
        IRequestHandler<DeleteClasseCommand, ResponseApi>
    {
    }
}
