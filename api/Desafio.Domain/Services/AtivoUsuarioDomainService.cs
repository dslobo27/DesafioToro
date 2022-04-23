using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class AtivoUsuarioDomainService : IAtivoUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IAtivoUsuarioRepository _repository;

        public AtivoUsuarioDomainService(IUnitOfWork unitOfWork, IAtivoUsuarioRepository ativoUsuarioRepository)
        {
            _unitOfWork = unitOfWork;
            _repository = ativoUsuarioRepository;
        }

        public async Task ComprarAtivo(AtivoUsuario ativoUsuario)
        {
            try
            {
                await _unitOfWork.BeginTransaction();

                var usuario = ativoUsuario.Usuario;
                var contaCorrente = usuario.ContaCorrente;
                var ativo = ativoUsuario.Ativo;

                var valorOperacao = ativo.Valor * ativoUsuario.Quantidade;

                if (contaCorrente.Saldo < valorOperacao)
                    throw new Exception("Saldo Insuficiente.");

                var ativoJaExistente = usuario.AtivosUsuario?.SingleOrDefault(x => x.AtivoId.Equals(ativo.Id));
                if (ativoJaExistente == null)
                {
                    ativo.QuantidadeNegociados += ativoUsuario.Quantidade;
                    usuario.AtivosUsuario.Add(ativoUsuario); 
                }                    
                else
                {
                    ativoJaExistente.Quantidade += ativoUsuario.Quantidade;
                    ativoJaExistente.Ativo.QuantidadeNegociados += ativoUsuario.Quantidade;
                }

                contaCorrente.Saldo -= valorOperacao;
                _unitOfWork.UsuarioRepository.AtualizarUsuario(usuario);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }
        }
    }
}