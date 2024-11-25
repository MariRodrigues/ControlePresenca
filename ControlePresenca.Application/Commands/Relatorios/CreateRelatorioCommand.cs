using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlePresenca.Application.Commands.Relatorios;

public class CreateRelatorioCommand : IRequest<ResponseApi>
{
    [Required]
    public int ClasseId { get; set; }
    public DateTime? Data { get; set; } = DateTime.Now;
    public string Observacao { get; set; }
    public double Oferta { get; set; }
    public int ProfessorId { get; set; }
    public int QuantidadeBiblias { get; set; }
    public int QuantidadeRevistas { get; set; }
    public int QuantidadeVisitantes { get; set; }
    public List<int> AlunosPresentesIds { get; set; }
}
