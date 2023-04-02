using AutoMapper;
using ControlePresenca.Application.Commands.Usuarios;
using ControlePresenca.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Profiles
{
    public class UsuarioProfile : Profile
    {
        public UsuarioProfile()
        {
            CreateMap<CreateUsuarioCommand, CustomUsuario>();
        }
    }
}
