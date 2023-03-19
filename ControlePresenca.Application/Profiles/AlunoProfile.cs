using AutoMapper;
using ControlePresenca.Application.Commands.Alunos;
using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Profiles
{
    public class AlunoProfile : Profile
    {
        public AlunoProfile()
        {
            CreateMap<CreateAlunoCommand, Aluno>();
            CreateMap<AlunoDTO, Aluno>();
        }
    }
}
