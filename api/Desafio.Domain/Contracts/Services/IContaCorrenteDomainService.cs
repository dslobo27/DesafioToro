using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Services
{
    public interface IContaCorrenteDomainService
    {
        Task<ContaCorrente> ObterPorId(Guid contaCorrenteId);
    }
}