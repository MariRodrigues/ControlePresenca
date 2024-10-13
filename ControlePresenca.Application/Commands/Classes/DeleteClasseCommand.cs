using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Commands.Classes;

public class DeleteClasseCommand(int id) : IRequest<ResponseApi>
{
    public int Id { get; set; } = id;
}
