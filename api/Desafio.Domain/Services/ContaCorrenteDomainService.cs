using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class ContaCorrenteDomainService : IContaCorrenteDomainService
    {
        private readonly IContaCorrenteRepository _repository;

        public ContaCorrenteDomainService(IContaCorrenteRepository repository)
        {
            _repository = repository;
        }

        public async Task<ContaCorrente> ObterPorId(Guid contaCorrenteId)
        {
            return await _repository.ObterPorId(contaCorrenteId);
        }
    }
}