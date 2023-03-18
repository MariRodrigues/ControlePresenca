using AutoMapper;
using ControlePresenca.Application.Commands.Aluno;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.AlunoHandlers
{
    public class AlunoHandler : IAlunoHandler
    {
        private readonly IClasseRepository _classeRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMapper _mapper;

        public AlunoHandler(IClasseRepository classeRepository, IAlunoRepository alunoRepository, IMapper mapper)
        {
            _classeRepository = classeRepository;
            _alunoRepository = alunoRepository;
            _mapper = mapper;
        }

        public async Task<ResponseApi> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
        {
            var classe = await _classeRepository.GetById(request.ClasseId);

            if (classe is null)
                return new ResponseApi(false, "A classe informada não existe");

            var aluno = _mapper.Map<Aluno>(request);

            var response = _alunoRepository.Cadastrar(aluno);

            if (response is null)
                return new ResponseApi(false, "Erro ao cadastrar aluno");

            return new ResponseApi(true, "Aluno cadastrado com sucesso");
        }
    }
}
