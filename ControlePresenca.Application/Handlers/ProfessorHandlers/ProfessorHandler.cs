using AutoMapper;
using ControlePresenca.Application.Commands.Professores;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.ProfessorHandlers;

public interface IProfessorHandler : IRequestHandler<CreateProfessorCommand, ResponseApi> { }

public class ProfessorHandler(
    IMapper mapper, 
    IProfessorRepository professorRepository) : IProfessorHandler
{
    public async Task<ResponseApi> Handle(CreateProfessorCommand request, CancellationToken cancellationToken)
    {
        var professor = mapper.Map<Professor>(request);

        var response = professorRepository.Cadastrar(professor);

        if (response is null)
            return new ResponseApi(false, "Erro ao cadastrar professor");

        return new ResponseApi(true, "Professor cadastrado com sucesso");
    }
}
