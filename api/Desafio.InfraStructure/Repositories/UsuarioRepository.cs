using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Desafio.InfraStructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void AtualizarUsuario(Usuario usuario)
        {
            _context.Update(usuario);
        }

        public async Task<Usuario> Login(string cpf, string senha)
        {
            return await _context.Usuarios.SingleOrDefaultAsync(x => x.CPF.Equals(cpf) && x.Senha.Equals(senha));
        }

        public async Task<Usuario> ObterPorId(Guid usuarioId)
        {
            return await _context.Usuarios
                .Include(x => x.ContaCorrente)
                .Include(x => x.AtivosUsuario)
                    .ThenInclude(x => x.Ativo)
                .SingleOrDefaultAsync(x => x.Id.Equals(usuarioId));
        }
    }
}