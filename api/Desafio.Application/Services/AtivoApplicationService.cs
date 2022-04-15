using AutoMapper;
using Desafio.Application.Contracts;
using Desafio.Application.Exceptions;
using Desafio.Application.Models.Ativos;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class AtivoApplicationService : IAtivoApplicationService
    {
        private readonly IAtivoDomainService _domainService;
        private readonly IUsuarioDomainService _usuarioDomainService;
        private readonly IAtivoUsuarioDomainService _ativoUsuarioDomainService;
        private readonly IMapper _mapper;

        public AtivoApplicationService(IAtivoDomainService domainService, IUsuarioDomainService usuarioDomainService,
            IAtivoUsuarioDomainService ativoUsuarioDomainService, IMapper mapper)
        {
            _domainService = domainService;
            _usuarioDomainService = usuarioDomainService;
            _ativoUsuarioDomainService = ativoUsuarioDomainService;
            _mapper = mapper;
        }

        public async Task ComprarAtivo(ComprarAtivoModel model)
        {
            var usuario = _mapper.Map<Usuario>(_usuarioDomainService.ObterPorId(model.UsuarioId));
            var ativo = _mapper.Map<Ativo>(_domainService.ObterPorId(model.AtivoId));

            var ativoUsuario = new AtivoUsuario
            {
                Ativo = ativo,
                AtivoId = model.AtivoId,
                Usuario = usuario,
                UsuarioId = model.UsuarioId,
                Quantidade = model.QuantidadeSolicitada
            };

            await _ativoUsuarioDomainService.ComprarAtivo(ativoUsuario);
        }

        public async Task<List<AtivoModel>> ObterCincoAtivosMaisNegociados()
        {
            return _mapper.Map<List<AtivoModel>>(await _domainService.ObterCincoAtivosMaisNegociados());
        }

        public async Task ValidarAtivo(Guid ativoId)
        {
            var ativo = await _domainService.ObterPorId(ativoId);

            if (ativo == null)
                throw new AtivoInvalidoException();
        }
    }
}