using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IContaCorrenteRepository
    {
        ContaCorrente ObterPorId(Guid contaCorrenteId);

        void AtualizarSaldo(ContaCorrente contaCorrente);
    }
}