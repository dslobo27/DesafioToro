using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorId(Guid usuarioId);
    }
}