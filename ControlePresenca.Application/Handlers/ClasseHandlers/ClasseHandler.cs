﻿using AutoMapper;
using ControlePresenca.Application.Commands.Classes;
using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using ControlePresenca.Infra.Repository;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Handlers.ClasseHandlers;

public interface IClasseHandler :
    IRequestHandler<CreateClasseCommand, ResponseApi>,
    IRequestHandler<DeleteClasseCommand, ResponseApi> { }

public class ClasseHandler(
    IMapper mapper, 
    IClasseRepository classeRepository) : IClasseHandler
{
    public async Task<ResponseApi> Handle(CreateClasseCommand request, CancellationToken cancellationToken)
    {
        var existingClass = await classeRepository.GetByNameAsync(request.Nome);
        if (existingClass != null)
        {
            return new ResponseApi(false, "Já existe uma classe com o mesmo nome.");
        }

        var classe = mapper.Map<Classe>(request);

        var response = await classeRepository.AddAsync(classe);

        if (response == null)
            return new ResponseApi(false, "Não foi possível cadastrar a classe");

        return new ResponseApi(true, "Classe cadastrada com sucesso");
    }

    public async Task<ResponseApi> Handle(DeleteClasseCommand request, CancellationToken cancellationToken)
    {
        var existingClass = await classeRepository.GetByIdAsync(request.Id);

        if (existingClass == null)
        {
            return new ResponseApi(false, "Não existe classe com esse Id.");
        }

        await classeRepository.DeleteAsync(existingClass);

        return new ResponseApi(true, "Classe deletada com sucesso");
    }
}
