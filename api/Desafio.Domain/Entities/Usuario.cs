using System;
using System.Collections.Generic;

namespace Desafio.Domain.Entities
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public Guid ContaCorrenteId { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Senha { get; set; }

        public ContaCorrente ContaCorrente { get; set; }
        public ICollection<AtivoUsuario> AtivosUsuario { get; set; }
    }
}