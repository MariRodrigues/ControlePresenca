using AutoMapper;
using ControlePresenca.Application.Commands.Alunos;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Application.Profiles;

public class AlunoProfile : Profile
{
    public AlunoProfile()
    {
        CreateMap<CreateAlunoCommand, Aluno>();
    }
}
