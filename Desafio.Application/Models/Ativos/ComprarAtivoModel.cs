using Desafio.Application.Models.Usuarios;
using System;

namespace Desafio.Application.Models.Ativos
{
    public class ComprarAtivoModel
    {
        public Guid AtivoId { get; set; }
        public Guid UsuarioId { get; set; }
        public int QuantidadeSolicitada { get; set; }
    }
}