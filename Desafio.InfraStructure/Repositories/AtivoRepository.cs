using Desafio.Domain.Contracts;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using System.Collections.Generic;
using System.Linq;

namespace Desafio.InfraStructure.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly DataContext _context;

        public AtivoRepository(DataContext context)
        {
            _context = context;
        }

        public List<Ativo> ObterCincoAtivosMaisNegociados()
        {
            return _context.Ativos.OrderByDescending(x => x.QuantidadeNegociados).Take(5).ToList();
        }
    }
}