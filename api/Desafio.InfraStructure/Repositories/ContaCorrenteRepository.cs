using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

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
            _context.Entry(contaCorrente).State = EntityState.Modified;
        }

        public ContaCorrente ObterPorId(Guid contaCorrenteId)
        {
            return _context.ContasCorrentes.SingleOrDefault(x => x.Id.Equals(contaCorrenteId));
        }
    }
}