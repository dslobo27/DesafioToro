using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IAtivoUsuarioRepository
    {
        Task<AtivoUsuario> Obter(Guid ativoId, Guid usuarioId);

        void AlterarAtivo(AtivoUsuario ativoUsuario);
    }
}