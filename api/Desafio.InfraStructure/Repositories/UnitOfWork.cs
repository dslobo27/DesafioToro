using Desafio.Domain.Contracts.Repositories;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore.Storage;
using System.Threading.Tasks;

namespace Desafio.InfraStructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DataContext _context;
        private IDbContextTransaction transaction;

        public UnitOfWork(DataContext context)
        {
            _context = context;
        }

        public async Task BeginTransaction()
        {
            transaction = await _context.Database.BeginTransactionAsync();
        }

        public async Task Commit()
        {
            await _context.SaveChangesAsync();
            await transaction.CommitAsync();
        }

        public async Task RollBack()
        {
            await transaction.RollbackAsync();
        }

        public IAtivoRepository AtivoRepository => new AtivoRepository(_context);
        public IAtivoUsuarioRepository AtivoUsuarioRepository => new AtivoUsuarioRepository(_context);
        public IContaCorrenteRepository ContaCorrenteRepository => new ContaCorrenteRepository(_context);
        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_context);
    }
}