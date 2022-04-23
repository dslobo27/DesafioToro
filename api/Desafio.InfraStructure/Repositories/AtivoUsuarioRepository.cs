using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

namespace Desafio.InfraStructure.Repositories
{
    public class AtivoUsuarioRepository : IAtivoUsuarioRepository
    {
        private readonly DataContext _context;

        public AtivoUsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void AlterarAtivo(AtivoUsuario ativoUsuario)
        {
            _context.Entry(ativoUsuario).State = EntityState.Modified;
        }

        public async Task<AtivoUsuario> Obter(Guid ativoId, Guid usuarioId)
        {
            return await _context.AtivosUsuario
                .Include(x => x.Ativo)
                .Include(x => x.Usuario)
                .SingleOrDefaultAsync(x => x.AtivoId.Equals(ativoId)
                    && x.UsuarioId.Equals(usuarioId));
        }
    }
}