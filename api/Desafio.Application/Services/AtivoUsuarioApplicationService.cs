using AutoMapper;
using Desafio.Application.Contracts;
using Desafio.Application.Models.AtivosUsuario;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class AtivoUsuarioApplicationService : IAtivoUsuarioApplicationService
    {
        private readonly IAtivoUsuarioDomainService _domainService;
        private readonly IMapper _mapper;

        public AtivoUsuarioApplicationService(IAtivoUsuarioDomainService domainService, IMapper mapper)
        {
            _domainService = domainService;
            _mapper = mapper;
        }

        public async Task ComprarAtivo(AtivoUsuarioModel ativoUsuarioModel)
        {
            await _domainService.ComprarAtivo(_mapper.Map<AtivoUsuario>(ativoUsuarioModel));
        }
    }
}