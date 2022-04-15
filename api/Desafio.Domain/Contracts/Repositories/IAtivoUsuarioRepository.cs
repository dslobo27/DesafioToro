using Desafio.Domain.Entities;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IAtivoUsuarioRepository
    {
        Task ComprarAtivo(AtivoUsuario ativoUsuario);
    }
}