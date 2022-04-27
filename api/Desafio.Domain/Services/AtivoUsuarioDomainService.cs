using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Contracts.Services;
using Desafio.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
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

                #region Variáveis
                var usuario = ativoUsuario.Usuario;
                var contaCorrente = usuario.ContaCorrente;
                var ativo = ativoUsuario.Ativo;
                #endregion

                decimal valorOperacao = ObterValorOperacao(ativoUsuario, ativo);

                ValidarSaldo(contaCorrente, valorOperacao);

                var ativoJaExistente = usuario.AtivosUsuario?.SingleOrDefault(x => x.AtivoId.Equals(ativo.Id));
                if (ativoJaExistente == null)
                {
                    ativo.QuantidadeNegociados += ativoUsuario.Quantidade;
                    usuario.AtivosUsuario ??= new List<AtivoUsuario>();
                    usuario.AtivosUsuario.Add(ativoUsuario);
                }
                else
                {
                    ativoJaExistente.Quantidade += ativoUsuario.Quantidade;
                    ativoJaExistente.Ativo.QuantidadeNegociados += ativoUsuario.Quantidade;
                }

                usuario.ContaCorrente.Saldo = DebitarSaldo(contaCorrente, valorOperacao);

                _unitOfWork.UsuarioRepository.AtualizarUsuario(usuario);

                await _unitOfWork.Commit();
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBack();
                throw new Exception(ex.Message);
            }
        }

        private static decimal DebitarSaldo(ContaCorrente contaCorrente, decimal valorOperacao)
        {
            contaCorrente.Saldo -= valorOperacao;
            return contaCorrente.Saldo;
        }

        private static void ValidarSaldo(ContaCorrente contaCorrente, decimal valorOperacao)
        {
            if (contaCorrente.Saldo < valorOperacao)
                throw new Exception("Saldo Insuficiente.");
        }

        private static decimal ObterValorOperacao(AtivoUsuario ativoUsuario, Ativo ativo)
        {
            return ativo.Valor * ativoUsuario.Quantidade;
        }
    }
}