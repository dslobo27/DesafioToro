using Desafio.Domain.Contracts;
using Desafio.InfraStructure.Context;

namespace Desafio.InfraStructure.Repositories
{
    internal class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }
    }
}