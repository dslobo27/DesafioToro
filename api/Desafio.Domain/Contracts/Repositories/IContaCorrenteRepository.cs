using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IContaCorrenteRepository
    {
        Task<ContaCorrente> ObterPorId(Guid contaCorrenteId);

        void AtualizarSaldo(ContaCorrente contaCorrente);
    }
}