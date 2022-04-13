using Desafio.Application.Contracts;
using Desafio.Application.Exceptions;
using Desafio.Domain.Contracts.Services;
using System;

namespace Desafio.Application.Services
{
    public class UsuarioApplicationService : IUsuarioApplicationService
    {
        private readonly IUsuarioDomainService _domainService;

        public UsuarioApplicationService(IUsuarioDomainService domainService)
        {
            _domainService = domainService;
        }

        public void ValidarUsuario(Guid usuarioId)
        {
            var usuario = _domainService.ObterPorId(usuarioId);

            if (usuario == null)
                throw new UsuarioInvalidoException();
        }
    }
}