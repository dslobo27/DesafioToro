using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        Task BeginTransaction();

        Task Commit();

        Task RollBack();

        IAtivoRepository AtivoRepository { get; }
        IAtivoUsuarioRepository AtivoUsuarioRepository { get; }
        IContaCorrenteRepository ContaCorrenteRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
    }
}