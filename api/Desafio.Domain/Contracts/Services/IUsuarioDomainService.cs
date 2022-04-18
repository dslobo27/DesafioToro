using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Services
{
    public interface IUsuarioDomainService
    {
        Task<Usuario> ObterPorId(Guid usuarioId);

        Task<Usuario> Login(string cpf, string senha);
    }
}