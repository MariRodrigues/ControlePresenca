using AutoMapper;
using ControlePresenca.Application.Commands.Presencas;
using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Application.Profiles;

public class PresencaProfile : Profile
{
    public PresencaProfile()
    {
        CreateMap<CreatePresencaCommand, Presenca>();
        CreateMap<UpdatePresencaDTO, Presenca>();

    }
}
