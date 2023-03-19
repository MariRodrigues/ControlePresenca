using AutoMapper;
using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Profiles
{
    public class ClasseProfile : Profile
    {
        public ClasseProfile()
        {
            CreateMap<CreateClasseCommand, Classe>();
        }
    }
}
