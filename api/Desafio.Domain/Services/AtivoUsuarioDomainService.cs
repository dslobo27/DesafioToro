using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Threading.Tasks;

namespace Desafio.Domain.Services
{
    public class AtivoUsuarioDomainService : IAtivoUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtivoUsuarioDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
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

                _unitOfWork.AtivoUsuarioRepository.ComprarAtivo(ativoUsuario);

                ativo.QuantidadeNegociados += ativoUsuario.Quantidade;

                _unitOfWork.AtivoRepository.AtualizarVendas(ativo);

                contaCorrente.Saldo -= valorOperacao;

                _unitOfWork.ContaCorrenteRepository.AtualizarSaldo(contaCorrente);

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