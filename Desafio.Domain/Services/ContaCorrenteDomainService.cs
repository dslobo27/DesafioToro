using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Services
{
    public class ContaCorrenteDomainService : IContaCorrenteDomainService
    {
        private readonly IContaCorrenteRepository _repository;
        private readonly IUnitOfWork _unitOfWork;

        public ContaCorrenteDomainService(IContaCorrenteRepository repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public ContaCorrente ObterPorId(Guid contaCorrenteId)
        {
            return _repository.ObterPorId(contaCorrenteId);
        }
    }
}