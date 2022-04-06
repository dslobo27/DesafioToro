using Desafio.Domain.Contracts;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Desafio.Domain.Services
{
    public class AtivoDomainService : IAtivoDomainService
    {
        private readonly IAtivoRepository _repository;

        public AtivoDomainService(IAtivoRepository repository)
        {
            _repository = repository;
        }

        public List<Ativo> ObterCincoAtivosMaisNegociados()
        {
            return _repository.ObterCincoAtivosMaisNegociados();
        }
    }
}