using AutoMapper;
using Azure.Core;
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
        private readonly IProfessorRepository _professorRepository;

        public RelatorioHandler(IMapper mapper, IClasseRepository classeRepository, IRelatorioRepository relatorioRepository, IAlunoRepository alunoRepository, IPresencaRepository presencaRepository, IProfessorRepository professorRepository)
        {
            _mapper = mapper;
            _classeRepository = classeRepository;
            _relatorioRepository = relatorioRepository;
            _alunoRepository = alunoRepository;
            _presencaRepository = presencaRepository;
            _professorRepository = professorRepository;
        }

        public async Task<ResponseApi> Handle(CreateRelatorioCommand request, CancellationToken cancellationToken)
        {
            var classe = await _classeRepository.GetById(request.ClasseId);
            if (classe is null)
                return new ResponseApi(false, "A classe informada não existe");

            var professor = _professorRepository.GetById(request.ProfessorId);
            if (professor is null)
                return new ResponseApi(false, "O professor informado não existe");

            var relatorio = _mapper.Map<Relatorio>(request);

            var newRelatorio = await _relatorioRepository.Cadastrar(relatorio);

            var presencas = CriarListaAlunosComPresencaFalse(newRelatorio.Id, classe);

            AtualizarPresencas(presencas, request.AlunosPresentesIds, classe, out var erros);

            newRelatorio.Presencas = presencas;

            await _relatorioRepository.Editar(newRelatorio);

            if (erros?.Count != 0)
            {
                return new ResponseApi(true, "Relatório cadastrado, mas há alunos não encontrados")
                {
                    Id = newRelatorio.Id,
                    Infos = erros 
                };
            }

            return new ResponseApi(true, "Relatório cadastrado com sucesso") { Id = newRelatorio.Id };
        }

        private static List<Presenca> CriarListaAlunosComPresencaFalse(int relatorioId, Classe classe)
        {
            var presencas = new List<Presenca>();

            foreach (var aluno in classe.Alunos)
            {
                Presenca presenca = new()
                {
                    RelatorioId = relatorioId,
                    AlunoId = aluno.Id,
                    Presente = false
                };

                presencas.Add(presenca);
            }

            return presencas;
        }

        private static void AtualizarPresencas(List<Presenca> presencas, List<int> alunosPresentesIds, Classe classe, out List<int> erros)
        {
            erros = new List<int>();

            foreach (var alunoId in alunosPresentesIds)
            {
                var alunoNaClasse = classe.Alunos.Any(a => a.Id == alunoId);

                if (alunoNaClasse)
                {
                    var presenca = presencas.FirstOrDefault(p => p.AlunoId == alunoId);
                    if (presenca != null)
                    {
                        presenca.Presente = true;
                    }
                }
                else
                {
                    erros.Add(alunoId);
                }
            }
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
