using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Contracts.Services
{
    public interface IUsuarioDomainService
    {
        Usuario ObterPorId(Guid usuarioId);
    }
}