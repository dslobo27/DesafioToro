using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;
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

        public async Task ComprarAtivo(AtivoUsuario ativoUsuario)
        {
            await _context.AddAsync(ativoUsuario);
        }
    }
}