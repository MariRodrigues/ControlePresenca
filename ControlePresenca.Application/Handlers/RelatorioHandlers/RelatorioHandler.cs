using AutoMapper;
using ControlePresenca.Application.Commands.Relatorio;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.RelatorioHandlers
{
    public class RelatorioHandler : IRelatorioHandler
    {
        private readonly IMapper _mapper;
        private readonly IClasseRepository _classeRepository;
        private readonly IRelatorioRepository _relatorioRepository;
        private readonly IAlunoRepository _alunoRepository;
        private readonly IPresencaRepository _presencaRepository;

        public RelatorioHandler(IMapper mapper, IClasseRepository classeRepository, IRelatorioRepository relatorioRepository, IAlunoRepository alunoRepository, IPresencaRepository presencaRepository)
        {
            _mapper = mapper;
            _classeRepository = classeRepository;
            _relatorioRepository = relatorioRepository;
            _alunoRepository = alunoRepository;
            _presencaRepository = presencaRepository;
        }

        public async Task<ResponseApi> Handle(CreateRelatorioCommand request, CancellationToken cancellationToken)
        {
            var classe = await _classeRepository.GetById(request.ClasseId);

            if (classe is null)
                return new ResponseApi(false, "A classe informada não existe");

            var relatorio = _mapper.Map<Relatorio>(request);

            var newRelatorio = await _relatorioRepository.Cadastrar(relatorio);

            if (newRelatorio is null)
                return new ResponseApi(false, "Erro ao cadastrar relatório");

            if (classe.Alunos.Any())
            {
                foreach (var aluno in classe.Alunos)
                {
                    Presenca presenca = new Presenca()
                    {
                        AlunoId = aluno.Id,
                        RelatorioId = newRelatorio.Id,
                        Presente = false
                    };

                    await _presencaRepository.Cadastrar(presenca);
                }
            }

            return new ResponseApi(true, "Relatório cadastrado com sucesso");
        }
    }
}
