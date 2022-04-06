using Desafio.Domain.Entities;
using System.Collections.Generic;

namespace Desafio.Domain.Contracts.Services
{
    public interface IAtivoDomainService
    {
        List<Ativo> ObterCincoAtivosMaisNegociados();
    }
}