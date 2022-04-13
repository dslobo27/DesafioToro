using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IAtivoUsuarioRepository
    {
        void ComprarAtivo(AtivoUsuario ativoUsuario);
    }
}