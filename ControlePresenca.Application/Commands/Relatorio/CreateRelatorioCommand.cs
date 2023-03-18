using ControlePresenca.Application.Response;
using MediatR;
using System;
using System.ComponentModel.DataAnnotations;

namespace ControlePresenca.Application.Commands.Relatorio
{
    public class CreateRelatorioCommand : IRequest<ResponseApi>
    {
        [Required]
        public DateTime Data { get; set; }
        [Required]
        public int ClasseId { get; set; }
        public string Observacao { get; set; }
        public double Oferta { get; set; }
        public int QuantidadeBiblias { get; set; }
        
    }
}
