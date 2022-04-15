using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class UsuarioDomainService : IUsuarioDomainService
    {
        private readonly IUsuarioRepository _repository;

        public UsuarioDomainService(IUsuarioRepository repository)
        {
            _repository = repository;
        }

        public async Task<Usuario> ObterPorId(Guid usuarioId)
        {
            return await _repository.ObterPorId(usuarioId);
        }
    }
}