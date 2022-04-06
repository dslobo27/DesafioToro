using AutoMapper;
using Desafio.Application.Contracts;
using Desafio.Application.Models.Ativos;
using Desafio.Domain.Contracts.Services;
using System.Collections.Generic;

namespace Desafio.Application.Services
{
    public class AtivoApplicationService : IAtivoApplicationService
    {
        private readonly IAtivoDomainService _domainService;
        private readonly IMapper _mapper;

        public AtivoApplicationService(IAtivoDomainService domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }

        public List<AtivoModel> ObterCincoAtivosMaisNegociados()
        {
            return _mapper.Map<List<AtivoModel>>(_domainService.ObterCincoAtivosMaisNegociados());
        }
    }
}