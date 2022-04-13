using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Desafio.InfraStructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly DataContext _context;

        public UsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public Usuario ObterPorId(Guid usuarioId)
        {
            return _context.Usuarios.Include(x => x.ContaCorrente)
                .SingleOrDefault(x => x.Id.Equals(usuarioId));
        }
    }
}