using Desafio.Application.Models.Usuarios;
using System;
using System.Threading.Tasks;

namespace Desafio.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        Task ValidarUsuario(Guid usuarioId);

        Task<UsuarioModel> Login(string cpf, string senha);

        Task<UsuarioModel> ObterPorId(Guid usuarioId);
    }
}