using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Application.Services;
using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("api/relatorio")]
    public class RelatorioController(IRelatorioQueries relatorioQueries, IDocumentServices documentServices) : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Cadastra novo relatório",
                          OperationId = "Post")]
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
                          OperationId = "Put")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Editar([FromServices] IMediator mediator, UpdateRelatorioCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os relatórios com filtros de Classe e/ou Data",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Buscar(int? classeId, DateTime? data, int pagina = 1, int quantidadeItens = 10)
        {
            var response = await relatorioQueries.GetAllFilter(classeId, data, pagina, quantidadeItens);
            return Ok(response);
        }

        [HttpGet("geral/planilha")]
        [SwaggerOperation(Summary = "Busca o relatório e gera um arquivo XLSX",
                          OperationId = "Get")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> GerarXlsx()
        {
            var response = await documentServices.GenerateRelatorioExcel();

            return File(response, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "RelatorioGeral.xlsx");
        }

        [HttpGet("{relatorioId}")]
        [SwaggerOperation(Summary = "Busca relatório por Id",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> BuscarPorId(int relatorioId)
        {
            var response = await relatorioQueries.GetRelatorioById(relatorioId);
            return Ok(response);
        }
    }
}
