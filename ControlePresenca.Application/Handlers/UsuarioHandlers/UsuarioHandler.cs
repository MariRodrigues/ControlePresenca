using AutoMapper;
using ControlePresenca.Application.Commands.Usuarios;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Repository;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.UsuarioHandlers;

public interface IUsuarioHandler :
    IRequestHandler<CreateUsuarioCommand, ResponseApi>,
    IRequestHandler<UpdateUsuarioCommand, ResponseApi>
{
}
public class UsuarioHandler(
    IMapper mapper, 
    ICustomUsuarioRepository userRepository) : IUsuarioHandler
{
    public async Task<ResponseApi> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
    {
        var identityUser = mapper.Map<CustomUsuario>(request);

        var user = await userRepository.GetByEmailAsync(request.Email);
        if (user is not null)
            return new ResponseApi(false, "E-mail existente.");

        var resultIdentity = await userRepository.AddAsync(identityUser, request.Password);

        if (!resultIdentity.Succeeded)
            return new ResponseApi(false, "Não foi possível cadastrar o usuário!");

        return new ResponseApi(true, "Usuário cadastrado com sucesso!");
    }

    public Task<ResponseApi> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }
}
