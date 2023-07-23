using AutoMapper;
using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Domain.Repository;
using System;
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
            relatorio.Data = DateTime.Now;

            var newRelatorio = await _relatorioRepository.Cadastrar(relatorio);

            if (newRelatorio is null)
                return new ResponseApi(false, "Erro ao cadastrar relatório");

            if (request.Presencas.Any())
            {
                foreach (var aluno in request.Presencas)
                {
                    Presenca presenca = new()
                    {
                        RelatorioId = newRelatorio.Id,
                        AlunoId = aluno.AlunoId,
                        Presente = aluno.Presente
                    };

                    await _presencaRepository.Cadastrar(presenca);
                }
            }

            return new ResponseApi(true, "Relatório cadastrado com sucesso") { Id = newRelatorio.Id };
        }

        public async Task<ResponseApi> Handle(UpdateRelatorioCommand request, CancellationToken cancellationToken)
        {
            var relatorio = await _relatorioRepository.GetById(request.Id);

            if (relatorio is null)
                return new ResponseApi(false, "O relatório não existe.");

            var presencas = await ValidPresenca(request.Id, request.Presencas);

            if (presencas is null)
                return new ResponseApi(false, "Há inconsistências nos alunos. ");

            relatorio.Update(request.Data, request.Observacao, request.Oferta, request.QuantidadeBiblias, presencas);

            var response = await _relatorioRepository.Editar(relatorio);

            if (response)
                return new ResponseApi(true, "Relatório atualizado com sucesso");
            else
                return new ResponseApi(false, "Não foi possível atualizar o relatório.");
        }


        private async Task<List<Presenca>> ValidPresenca(int relatrorioId, List<UpdatePresencaDTO> presencaList)
        {
            List<Presenca> presencas = new();

            foreach (var newPresenca in presencaList)
            {
                var presenca = await _presencaRepository.GetByAlunoRelatorioId(newPresenca.AlunoId, relatrorioId);

                if (presenca is null)
                    return null;

                presenca.Presente = newPresenca.Presente;

                presencas.Add(presenca);
            }

            return presencas;
        }
    }
}
