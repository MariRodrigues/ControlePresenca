using AutoMapper;
using ControlePresenca.Application.Commands.Usuarios;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.UsuarioHandlers
{
    public class UsuarioHandler : IUsuarioHandler
    {
        private readonly IMapper _mapper;
        private readonly ICustomUsuarioRepository _userRepository;

        public UsuarioHandler(IMapper mapper, ICustomUsuarioRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<ResponseApi> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var identityUser = _mapper.Map<CustomUsuario>(request);

            var user = await _userRepository.BuscarPorEmail(request.Email);
            if (user is not null)
                return new ResponseApi(false, "E-mail existente.");

            var resultIdentity = await _userRepository.Cadastrar(identityUser, request.Password);

            if (!resultIdentity.Succeeded)
                return new ResponseApi(false, "Não foi possível cadastrar o usuário!");

            return new ResponseApi(true, "Usuário cadastrado com sucesso!");
        }

        public Task<ResponseApi> Handle(UpdateUsuarioCommand request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
