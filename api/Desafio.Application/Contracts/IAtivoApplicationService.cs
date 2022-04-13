using Desafio.Application.Models.Ativos;
using System;
using System.Collections.Generic;

namespace Desafio.Application.Contracts
{
    public interface IAtivoApplicationService
    {
        List<AtivoModel> ObterCincoAtivosMaisNegociados();
        void ComprarAtivo(ComprarAtivoModel model);
        void ValidarAtivo(Guid ativoId);
    }
}