using System;

namespace Desafio.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Guid ContaCorrenteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }

        public ContaCorrente ContaCorrente { get; set; }
    }
}