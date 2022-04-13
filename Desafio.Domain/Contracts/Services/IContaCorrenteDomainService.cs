using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Contracts.Services
{
    public interface IContaCorrenteDomainService
    {
        ContaCorrente ObterPorId(Guid contaCorrenteId);
    }
}