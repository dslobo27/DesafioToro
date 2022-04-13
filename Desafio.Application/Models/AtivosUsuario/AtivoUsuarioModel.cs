using Desafio.Application.Models.Ativos;
using Desafio.Application.Models.Usuarios;
using System;

namespace Desafio.Application.Models.AtivosUsuario
{
    public class AtivoUsuarioModel
    {
        public Guid Id { get; set; }
        public AtivoModel AtivoModel { get; set; }
        public UsuarioModel UsuarioModel { get; set; }
    }
}