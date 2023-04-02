using AutoMapper;
using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Profiles
{
    public class RelatorioProfile : Profile
    {
        public RelatorioProfile()
        {
            CreateMap<CreateRelatorioCommand, Relatorio>();
            CreateMap<UpdateRelatorioCommand, Relatorio>();
        }
    }
}
