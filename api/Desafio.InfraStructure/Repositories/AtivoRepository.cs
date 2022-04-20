using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.InfraStructure.Repositories
{
    public class AtivoRepository : IAtivoRepository
    {
        private readonly DataContext _context;

        public AtivoRepository(DataContext context)
        {
            _context = context;
        }

        public void AtualizarVendas(Ativo ativo)
        {
            _context.Update(ativo);
        }

        public async Task<List<Ativo>> ObterCincoAtivosMaisNegociados()
        {
            return await _context.Ativos.AsNoTracking().OrderByDescending(x => x.QuantidadeNegociados).Take(5).ToListAsync();
        }

        public async Task<Ativo> ObterPorId(Guid ativoId)
        {
            return await _context.Ativos.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(ativoId));
        }
    }
}