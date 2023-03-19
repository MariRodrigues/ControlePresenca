using ControlePresenca.Application.Commands.Relatorios;
using ControlePresenca.Domain.Query;
using ControlePresenca.Domain.Repository;
using MediatR;
using Microsoft.AspNetCore.JsonPatch.Operations;
using Microsoft.AspNetCore.Mvc;
using Swashbuckle.AspNetCore.Annotations;
using System;
using System.Threading.Tasks;

namespace ControlePresenca.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RelatorioController : ControllerBase
    {
        private readonly IRelatorioQueries _relatorioQueries;
        private readonly IRelatorioRepository _relatorioRepository;

        public RelatorioController(IRelatorioQueries relatorioQueries, IRelatorioRepository relatorioRepository)
        {
            _relatorioQueries = relatorioQueries;
            _relatorioRepository = relatorioRepository;
        }

        [HttpPost]
        [ProducesResponseType(200)]
        [SwaggerOperation(Summary = "Cadastra novo relatório",
                          OperationId = "Post")]
        public async Task<IActionResult> Cadastrar([FromServices] IMediator mediator, CreateRelatorioCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpPut]
        [SwaggerOperation(Summary = "Edita relatório",
                          OperationId = "Put")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Editar([FromServices] IMediator mediator, EditRelatorioCommand command)
        {
            var response = await mediator.Send(command);
            return Ok(response);
        }

        [HttpGet]
        [SwaggerOperation(Summary = "Busca todos os relatórios com filtros de Classe e/ou Data",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> Buscar(int? classeId, DateTime? data)
        {
            var response = await _relatorioQueries.GetAllFilter(classeId, data);
            return Ok(response);
        }

        [HttpGet("{RelatorioId}")]
        [SwaggerOperation(Summary = "Busca relatório por Id",
                          OperationId = "Post")]
        [ProducesResponseType(200)]
        public async Task<IActionResult> BuscarPorId(int RelatorioId)
        {
            var response = await _relatorioQueries.GetRelatorioById(RelatorioId);
            return Ok(response);
        }
    }
}
