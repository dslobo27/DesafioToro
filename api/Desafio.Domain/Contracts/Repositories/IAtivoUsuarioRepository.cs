using Desafio.Domain.Entities;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IAtivoUsuarioRepository
    {
        void ComprarAtivo(AtivoUsuario ativoUsuario);
    }
}