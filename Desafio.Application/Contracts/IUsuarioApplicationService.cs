using System;

namespace Desafio.Application.Contracts
{
    public interface IUsuarioApplicationService
    {
        void ValidarUsuario(Guid usuarioId);
    }
}