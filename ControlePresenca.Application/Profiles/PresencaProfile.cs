using AutoMapper;
using ControlePresenca.Application.Commands.Presenca;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Application.Profiles
{
    public class PresencaProfile : Profile
    {
        public PresencaProfile()
        {
            CreateMap<CreatePresencaCommand, Presenca>();

        }
    }
}
