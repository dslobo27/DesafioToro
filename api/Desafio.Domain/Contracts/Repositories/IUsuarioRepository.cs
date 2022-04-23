using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Contracts.Repositories
{
    public interface IUsuarioRepository
    {
        Task<Usuario> ObterPorId(Guid usuarioId);
        Task<Usuario> Login(string cpf, string senha);
        void AtualizarUsuario(Usuario usuario);
    }
}