using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.InfraStructure.Context;

namespace Desafio.InfraStructure.Repositories
{
    public class AtivoUsuarioRepository : IAtivoUsuarioRepository
    {
        private readonly DataContext _context;

        public AtivoUsuarioRepository(DataContext context)
        {
            _context = context;
        }

        public void ComprarAtivo(AtivoUsuario ativoUsuario)
        {
            _context.Update(ativoUsuario);
        }
    }
}