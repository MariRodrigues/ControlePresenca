﻿using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ControlePresenca.Domain.Entities;

public class Relatorio
{
    public int Id { get; set; }
    public DateTime Data { get; set; }
    public string Observacao { get; set; }
    public virtual Classe Classe { get; set; }
    public double Oferta { get; set; }
    public virtual Professor Professor { get; set; }
    public int ProfessorId { get; set; }
    public int QuantidadeBiblias { get; set; }
    public int QuantidadeRevistas { get; set; }
    public int QuantidadeVisitantes { get; set; }                  
    public int ClasseId { get; set; }
    [JsonIgnore]
    public virtual List<Presenca> Presencas { get; set; }

    public void Update(DateTime data, string observacao, double oferta, int quantidadeBiblias, List<Presenca> presencas)
    {
        Data = data;
        Observacao = observacao;
        Oferta = oferta;
        QuantidadeBiblias = quantidadeBiblias;
        Presencas = presencas;
    }
}
