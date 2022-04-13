using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;

namespace Desafio.Domain.Contracts.Services
{
    public interface IAtivoDomainService
    {
        List<Ativo> ObterCincoAtivosMaisNegociados();
        Ativo ObterPorId(Guid ativoId);
    }
}