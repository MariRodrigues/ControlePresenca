using AutoMapper;
using ControlePresenca.Application.Commands.Professores;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.ProfessorHandlers
{
    public class ProfessorHandler : IProfessorHandler
    {
        private readonly IClasseRepository _classeRepository;
        private readonly IMapper _mapper;
        private readonly IProfessorRepository _professorRepository;

        public ProfessorHandler(IClasseRepository classeRepository, IMapper mapper, IProfessorRepository professorRepository)
        {
            _classeRepository = classeRepository;
            _mapper = mapper;
            _professorRepository = professorRepository;
        }

        public async Task<ResponseApi> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
        {
            var classe = await _classeRepository.GetById(request.ClasseId);

            if (classe is null)
                return new ResponseApi(false, "A categoria informada não existe");

            var professor = _mapper.Map<Professor>(request);

            var response = _professorRepository.Cadastrar(professor);

            if (response is null)
                return new ResponseApi(false, "Erro ao cadastrar professor");

            return new ResponseApi(true, "Professor cadastrado com sucesso");
        }
    }
}
