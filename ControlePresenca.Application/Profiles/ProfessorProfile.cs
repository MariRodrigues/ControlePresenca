using AutoMapper;
using ControlePresenca.Application.Commands.Professores;
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
