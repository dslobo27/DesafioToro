using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
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

        public void AtualizarVendas(Ativo ativo)
        {
            _context.Entry(ativo).State = EntityState.Modified;
        }

        public List<Ativo> ObterCincoAtivosMaisNegociados()
        {
            return _context.Ativos.OrderByDescending(x => x.QuantidadeNegociados).Take(5).ToList();
        }

        public Ativo ObterPorId(Guid ativoId)
        {
            return _context.Ativos.SingleOrDefault(x => x.Id.Equals(ativoId));
        }
    }
}