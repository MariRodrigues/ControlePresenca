using AutoMapper;
using ControlePresenca.Application.Commands.Usuarios;
using ControlePresenca.Domain.Entities;

namespace ControlePresenca.Application.Profiles;

public class UsuarioProfile : Profile
{
    public UsuarioProfile()
    {
        CreateMap<CreateUsuarioCommand, CustomUsuario>();
    }
}
