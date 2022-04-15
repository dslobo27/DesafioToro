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

        public async Task<Usuario> ObterPorId(Guid usuarioId)
        {
            return await _context.Usuarios.Include(x => x.ContaCorrente)
                .SingleOrDefaultAsync(x => x.Id.Equals(usuarioId));
        }
    }
}