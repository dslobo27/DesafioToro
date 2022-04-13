using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;

namespace Desafio.Domain.Services
{
    public class AtivoUsuarioDomainService : IAtivoUsuarioDomainService
    {
        private readonly IUnitOfWork _unitOfWork;

        public AtivoUsuarioDomainService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public void ComprarAtivo(AtivoUsuario ativoUsuario)
        {
            try
            {
                _unitOfWork.BeginTransaction();

                var usuario = _unitOfWork.UsuarioRepository.ObterPorId(ativoUsuario.UsuarioId);

                var contaCorrente = usuario.ContaCorrente;
                var ativo = _unitOfWork.AtivoRepository.ObterPorId(ativoUsuario.AtivoId);

                var valorOperacao = ativo.Valor * ativoUsuario.Quantidade;

                if (contaCorrente.Saldo < valorOperacao)
                    throw new Exception("Saldo Insuficiente.");

                _unitOfWork.AtivoUsuarioRepository.ComprarAtivo(ativoUsuario);                

                ativo.QuantidadeNegociados += ativoUsuario.Quantidade; 
                
                _unitOfWork.AtivoRepository.AtualizarVendas(ativo);

                contaCorrente.Saldo -= valorOperacao;

                _unitOfWork.ContaCorrenteRepository.AtualizarSaldo(contaCorrente);

                _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                _unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }
            
        }
    }
}