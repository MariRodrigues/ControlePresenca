using ControlePresenca.Application.Commands.Usuarios;
using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.UsuarioHandlers
{
    public interface IUsuarioHandler : 
        IRequestHandler<CreateUsuarioCommand, ResponseApi>, 
        IRequestHandler<UpdateUsuarioCommand, ResponseApi>
    {
    }
}
