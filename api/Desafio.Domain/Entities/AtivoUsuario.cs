using System;

namespace Desafio.Domain.Entities
{
    public class AtivoUsuario
    {
        public Guid AtivoId { get; set; }
        public Guid UsuarioId { get; set; }
        public int Quantidade { get; set; }

        public Ativo Ativo { get; set; }
        public Usuario Usuario { get; set; }
    }
}