using AutoMapper;
using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Application.Profiles;

public class ClasseProfile : Profile
{
    public ClasseProfile()
    {
        CreateMap<CreateClasseCommand, Classe>();
    }
}
