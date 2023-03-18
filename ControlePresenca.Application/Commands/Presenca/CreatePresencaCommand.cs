using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Commands.Presenca
{
    public class CreatePresencaCommand : IRequest<ResponseApi>
    {
        public int AlunoId { get; set; }
        public int RelatorioId { get; set; }
    }
}
