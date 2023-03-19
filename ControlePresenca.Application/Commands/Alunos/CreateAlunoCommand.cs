using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Commands.Alunos
{
    public class CreateAlunoCommand : IRequest<ResponseApi>
    {
        public string Nome { get; set; }
        public int ClasseId { get; set; }
    }
}
