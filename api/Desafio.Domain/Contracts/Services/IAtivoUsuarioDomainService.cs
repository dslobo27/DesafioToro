using Desafio.Domain.Entities;

namespace Desafio.Domain.Contracts.Services
{
    public interface IAtivoUsuarioDomainService
    {
        void ComprarAtivo(AtivoUsuario ativoUsuario);
    }
}