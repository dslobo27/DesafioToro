using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IAtivoRepository
    {
        List<Ativo> ObterCincoAtivosMaisNegociados();
        Ativo ObterPorId(Guid ativoId);
        void AtualizarVendas(Ativo ativo);
    }
}