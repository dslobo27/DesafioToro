using System;
using System.Threading.Tasks;

namespace Desafio.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        Task ValidarUsuario(Guid usuarioId);
    }
}