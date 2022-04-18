using Desafio.Application.Models.AtivosUsuario;
using Desafio.Application.Models.ContasCorrentes;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Models.Usuarios
{
    public class UsuarioModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }

        public ContaCorrenteModel ContaCorrente { get; set; }
        public List<AtivoUsuarioModel> AtivosUsuario { get; set; }
    }
}