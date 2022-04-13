using System;

namespace Desafio.Application.Exceptions
{
    public class AtivoInvalidoException : Exception
    {
        public override string Message => "Ativo inválido.";
    }
}