using System;
using System.Collections.Generic;

namespace Desafio.Domain.Entities
{
    public class Ativo
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public decimal Valor { get; set; }
        public int QuantidadeNegociados { get; set; }

        public List<AtivoUsuario> AtivosUsuario { get; set; }
    }
}