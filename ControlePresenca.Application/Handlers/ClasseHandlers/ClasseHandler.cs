using AutoMapper;
using ControlePresenca.Application.Commands.Classe;
using ControlePresenca.Application.Handlers.ClasseHandlers;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.ClasseHandlers
{
    public class ClasseHandler : IClasseHandler
    {
        private readonly IMapper _mapper;
        private readonly IClasseRepository _classeRepository;

        public ClasseHandler(IMapper mapper, IClasseRepository classeRepository)
        {
            _mapper = mapper;
            _classeRepository = classeRepository;
        }

        public async Task<ResponseApi> Handle(CreateClasseCommand request, CancellationToken cancellationToken)
        {
            var classe = _mapper.Map<Classe>(request);

            var response = _classeRepository.Cadastrar(classe);

            if (response == null)
                return new ResponseApi(false, "Não foi possível cadastrar a classe");

            return new ResponseApi(true, "Classe cadastrada com sucesso");
        }
    }
}
