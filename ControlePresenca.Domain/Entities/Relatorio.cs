﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace ControlePresenca.Domain.Entities
{
    public class Relatorio
    {
        public int Id { get; set; }
        public DateTime Data { get; set; }
        public string Observacao { get; set; }
        public virtual Classe Classe { get; set; }
        public double Oferta { get; set; }
        public int QuantidadeBiblias { get; set; }
        public int ClasseId { get; set; }
        [JsonIgnore]
        public virtual List<Presenca> Presencas { get; set; }
        [JsonIgnore]
        public virtual List<Visitante> Visitantes { get; set; }
    }
}