using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Services
{
    public interface IAtivoDomainService
    {
        Task<List<Ativo>> ObterCincoAtivosMaisNegociados();

        Task<Ativo> ObterPorId(Guid ativoId);
    }
}