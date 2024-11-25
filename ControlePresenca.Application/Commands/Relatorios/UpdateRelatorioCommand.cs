using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.Collections.Generic;

namespace ControlePresenca.Application.Commands.Relatorios;

public class UpdateRelatorioCommand : IRequest<ResponseApi>
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Observacao { get; set; }
    public double Oferta { get; set; }
    public int QuantidadeBiblias { get; set; }
    public int ProfessorId { get; set; }
    public virtual List<UpdatePresencaDTO> Presencas { get; set; }
}

public class UpdatePresencaDTO
{
    public int AlunoId { get; set; }
    public bool Presente { get; set; }
}
