using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Usuario ObterPorId(Guid usuarioId);
    }
}