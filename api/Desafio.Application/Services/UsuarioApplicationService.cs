using AutoMapper;
using Desafio.Application.Contracts;
using Desafio.Application.Exceptions;
using Desafio.Application.Models.Usuarios;
using Desafio.Domain.Contracts.Services;
using System;
using System.Threading.Tasks;

namespace Desafio.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService _domainService;
        private readonly IMapper _mapper;

        public UsuarioApplicationService(IMapper mapper, IUsuarioDomainService domainService)
        {
            _domainService = domainService;
            _mapper = mapper;
        }

        public async Task<UsuarioModel> Login(string cpf, string senha)
        {
            return _mapper.Map<UsuarioModel>(await _domainService.Login(cpf, senha));
        }

        public async Task<UsuarioModel> ObterPorId(Guid usuarioId)
        {
            return _mapper.Map<UsuarioModel>(await _domainService.ObterPorId(usuarioId));
        }

        public async Task ValidarUsuario(Guid usuarioId)
        {
            var usuario = await _domainService.ObterPorId(usuarioId);

            if (usuario == null)
                throw new UsuarioInvalidoException();
        }
    }
}