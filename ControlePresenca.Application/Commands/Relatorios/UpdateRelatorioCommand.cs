using ControlePresenca.Application.Response;
using ControlePresenca.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControlePresenca.Application.Commands.Relatorios
{
    public class UpdateRelatorioCommand : IRequest<ResponseApi>
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public double Oferta { get; set; }
        public int QuantidadeBiblias { get; set; }
        public virtual List<PresencaDTO> Presencas { get; set; }
        public virtual List<VisitanteDTO> Visitantes { get; set; }
    }

    public class PresencaDTO
    {
        public int AlunoId { get; set; }
        public bool Presente { get; set; }
        public AlunoDTO Aluno { get; set; }
    }

    public class AlunoDTO
    {
        public string Nome { get; set; }
    }

    public class VisitanteDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
