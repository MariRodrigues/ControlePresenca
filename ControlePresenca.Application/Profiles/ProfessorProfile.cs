using AutoMapper;
using ControlePresenca.Application.Commands.Professor;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Application.Profiles
{
    public class ProfessorProfile : Profile
    {
        public ProfessorProfile()
        {
            CreateMap<CreateProfessorCommand, Professor>();
        }
    }
}
