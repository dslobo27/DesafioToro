using System;

namespace Desafio.Application.Models.Ativos
{
    public class AtivoModel
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeNegociados { get; set; }
    }
}