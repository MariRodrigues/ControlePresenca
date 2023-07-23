using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ControlePresenca.Application.Commands.Relatorios
{
    public class CreateRelatorioCommand : IRequest<ResponseApi>
    {
        [Required]
        public int ClasseId { get; set; }
        public string Observacao { get; set; }
        public double Oferta { get; set; }
        public int QuantidadeBiblias { get; set; }
        public int QuantidadeRevistas { get; set; }
        public int QuantidadeVisitantes { get; set; }
        public List<CreatePresencaDTO> Presencas { get; set; }
    }

    public class CreatePresencaDTO
    {
        public int AlunoId { get; set; }
        public bool Presente { get; set; }
    }
}
