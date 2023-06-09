﻿using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Commands.Classes
{
    public class CreateClasseCommand : IRequest<ResponseApi>
    {
        public string Nome { get; set; }
    }
}
