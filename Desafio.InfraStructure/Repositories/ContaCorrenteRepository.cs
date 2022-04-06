using Desafio.Domain.Contracts;
using Desafio.InfraStructure.Context;

namespace Desafio.InfraStructure.Repositories
{
    internal class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly DataContext _context;

        public ContaCorrenteRepository(DataContext context)
        {
            _context = context;
        }
    }
}