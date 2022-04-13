using System;

namespace Desafio.Application.Exceptions
{
    public class UsuarioInvalidoException : Exception
    {
        public override string Message => "Usuário inválido.";
    }
}