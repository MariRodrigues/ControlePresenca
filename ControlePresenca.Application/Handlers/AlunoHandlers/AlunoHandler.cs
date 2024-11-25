using AutoMapper;
using ControlePresenca.Application.Commands.Alunos;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.AlunoHandlers;

public interface IAlunoHandler : IRequestHandler<CreateAlunoCommand, ResponseApi> { }

public class AlunoHandler(
    IClasseRepository classeRepository, 
    IAlunoRepository alunoRepository, 
    IMapper mapper) : IAlunoHandler
{
    public async Task<ResponseApi> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
    {
        var classe = await classeRepository.GetById(request.ClasseId);

        if (classe is null)
            return new ResponseApi(false, "A classe informada não existe");

        var aluno = mapper.Map<Aluno>(request);

        var response = alunoRepository.Cadastrar(aluno);

        if (response is null)
            return new ResponseApi(false, "Erro ao cadastrar aluno");

        return new ResponseApi(true, "Aluno cadastrado com sucesso");
    }
}
