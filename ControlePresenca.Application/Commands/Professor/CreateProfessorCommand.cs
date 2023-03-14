using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Commands.Professor
{
    public class CreateProfessorCommand : IRequest<ResponseApi>
    {
        public string Nome { get; set; }
        public int ClasseId { get; set; }
    }

}
