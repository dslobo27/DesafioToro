using Desafio.Domain.Contracts.Repositories;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore.Storage;

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

        public void BeginTransaction()
        {
            transaction = _context.Database.BeginTransaction();
        }

        public void Commit()
        {
            _context.SaveChanges();
            transaction.Commit();
        }

        public void RollBack()
        {
            transaction.Rollback();
        }

        public IAtivoRepository AtivoRepository => new AtivoRepository(_context);
        public IAtivoUsuarioRepository AtivoUsuarioRepository => new AtivoUsuarioRepository(_context);
        public IContaCorrenteRepository ContaCorrenteRepository => new ContaCorrenteRepository(_context);
        public IUsuarioRepository UsuarioRepository => new UsuarioRepository(_context);
    }
}