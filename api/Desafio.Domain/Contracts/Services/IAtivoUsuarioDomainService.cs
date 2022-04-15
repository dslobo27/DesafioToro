using Desafio.Domain.Entities;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Services
{
    public interface IAtivoUsuarioDomainService
    {
        Task ComprarAtivo(AtivoUsuario ativoUsuario);
    }
}