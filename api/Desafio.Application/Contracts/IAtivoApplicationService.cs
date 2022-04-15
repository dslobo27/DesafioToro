using Desafio.Application.Models.Ativos;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Application.Contracts
{
    public interface IAtivoApplicationService
    {
        Task<List<AtivoModel>> ObterCincoAtivosMaisNegociados();

        Task ComprarAtivo(ComprarAtivoModel model);

        Task ValidarAtivo(Guid ativoId);
    }
}