using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IAtivoRepository
    {
        Task<List<Ativo>> ObterCincoAtivosMaisNegociados();

        Task<Ativo> ObterPorId(Guid ativoId);

        void AtualizarVendas(Ativo ativo);
    }
}