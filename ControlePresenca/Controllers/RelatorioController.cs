﻿using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Application.Services;
using Swashbuckle.AspNetCore.Annotations;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using System;
using ControlePresenca.Infra.Query;
using Microsoft.AspNetCore.Authorization;

namespace ControlePresenca.Controllers;

[ApiController]
[Route("api/relatorio")]
[Authorize]
public class RelatorioController(
    IRelatorioQueries relatorioQueries, 
    IDocumentServices documentServices) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(200)]
    [SwaggerOperation(Summary = "Cadastra novo relatório",
                      OperationId = "Cadastrar")]
    public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateRelatorioCommand command)
    {
        var response = await mediator.Send(command);

        if (response.Infos != null)
        {
            return StatusCode(206, response);
        }

        return Ok(response);
    }

    [HttpPut]
    [SwaggerOperation(Summary = "Edita relatório",
                      OperationId = "Editar")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Editar([FromServices] IMediator mediator, UpdateRelatorioCommand command)
    {
        var response = await mediator.Send(command);
        return Ok(response);
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Busca todos os relatórios com filtros de Classe e/ou Data",
                      OperationId = "Buscar")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> Buscar(
        int? classeId, 
        DateTime? startDate, 
        DateTime? endDate, 
        int pagina = 1, 
        int quantidadeItens = 10)
    {
        var response = await relatorioQueries.GetAllFilter(classeId, startDate, endDate, pagina, quantidadeItens);
        return Ok(response);
    }

    [HttpGet("geral/planilha")]
    [SwaggerOperation(Summary = "Busca o relatório e gera um arquivo XLSX",
                      OperationId = "GerarXlsx")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> GerarXlsx()
    {
        var response = await documentServices.GenerateRelatorioExcel();

        return File(response, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RelatorioGeral.xlsx");
    }

    [HttpGet("{relatorioId}")]
    [SwaggerOperation(Summary = "Busca relatório por Id",
                      OperationId = "BuscarPorId")]
    [ProducesResponseType(200)]
    public async Task<IActionResult> BuscarPorId(int relatorioId)
    {
        var response = await relatorioQueries.GetRelatorioById(relatorioId);
        return Ok(response);
    }
}
