using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class AtivoDomainService : IAtivoDomainService
    {
        private readonly IAtivoRepository _repository;

        public AtivoDomainService(IAtivoRepository repository)
        {
            _repository = repository;
        }

        public async Task<List<Ativo>> ObterCincoAtivosMaisNegociados()
        {
            return await _repository.ObterCincoAtivosMaisNegociados();
        }

        public async Task<Ativo> ObterPorId(Guid ativoId)
        {
            return await _repository.ObterPorId(ativoId);
        }
    }
}