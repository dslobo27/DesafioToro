using Desafio.Application.Models.Ativos;
using System.Collections.Generic;

namespace Desafio.Application.Contracts
{
    public interface IAtivoApplicationService
    {
        List<AtivoModel> ObterCincoAtivosMaisNegociados();
    }
}