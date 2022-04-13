using Desafio.Domain.Contracts;
using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioDomainService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public Usuario ObterPorId(Guid usuarioId)
        {
            return _repository.ObterPorId(usuarioId);
        }
    }
}