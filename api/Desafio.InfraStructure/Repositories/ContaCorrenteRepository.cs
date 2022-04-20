using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Desafio.InfraStructure.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly DataContext _context;

        public ContaCorrenteRepository(DataContext context)
        {
            _context = context;
        }

        public void AtualizarSaldo(ContaCorrente contaCorrente)
        {
            _context.Update(contaCorrente);
        }

        public async Task<ContaCorrente> ObterPorId(Guid contaCorrenteId)
        {
            return await _context.ContasCorrentes.AsNoTracking().SingleOrDefaultAsync(x => x.Id.Equals(contaCorrenteId));
        }
    }
}