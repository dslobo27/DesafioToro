using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Desafio.Domain.Services
{
    public class AtivoDomainService : IAtivoDomainService
    {
        private readonly IAtivoRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public AtivoDomainService(IAtivoRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public List<Ativo> ObterCincoAtivosMaisNegociados()
        {
            return _repository.ObterCincoAtivosMaisNegociados();
        }

        public Ativo ObterPorId(Guid ativoId)
        {
            return _repository.ObterPorId(ativoId);
        }
    }
}