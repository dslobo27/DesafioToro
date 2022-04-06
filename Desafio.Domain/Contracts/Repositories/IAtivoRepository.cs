using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Desafio.Domain.Contracts
{
    public interface IAtivoRepository
    {
        List<Ativo> ObterCincoAtivosMaisNegociados();
    }
}