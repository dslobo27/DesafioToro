namespace Desafio.Domain.Contracts.Repositories
{
    public interface IUnitOfWork
    {
        void BeginTransaction();

        void Commit();

        void RollBack();

        IAtivoRepository AtivoRepository { get; }
        IAtivoUsuarioRepository AtivoUsuarioRepository { get; }
        IContaCorrenteRepository ContaCorrenteRepository { get; }
        IUsuarioRepository UsuarioRepository { get; }
    }
}