using AutoFixture;
using Desafio.Domain.Contracts.Repositories;
using Desafio.Domain.Entities;
using Desafio.Domain.Services;
using FluentAssertions;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.Domain.Tests
{
    public class AtivoUsuarioDomainServiceTest
    {
        private readonly Mock<IUnitOfWork> _unitOfWorkMock = new();
        private readonly Mock<IUsuarioRepository> _usuarioRepositoryMock = new();

        public AtivoUsuarioDomainService _ativoUsuarioDomainService;
        public AtivoUsuario _ativoUsuario;

        public AtivoUsuarioDomainServiceTest()
        {
            _ativoUsuarioDomainService = new AtivoUsuarioDomainService(_unitOfWorkMock.Object);

            _unitOfWorkMock.Setup(uow => uow.UsuarioRepository).Returns(_usuarioRepositoryMock.Object);
            
            var fixture = new Fixture();
            fixture.Behaviors.Remove(new ThrowingRecursionBehavior());
            fixture.Behaviors.Add(new OmitOnRecursionBehavior());

            _ativoUsuario = fixture.Create<AtivoUsuario>();

            _ativoUsuario.Ativo.Valor = 25M;
            _ativoUsuario.Ativo.QuantidadeNegociados = 0;
            _ativoUsuario.Quantidade = 2;
            _ativoUsuario.Usuario.ContaCorrente.Saldo = 200;
        }

        [Fact]
        public async Task ComprarAtivoAsync_DeveInserirAtivoParaUsuario()
        {
            _ativoUsuario.Usuario.AtivosUsuario = null;
            await _ativoUsuarioDomainService.ComprarAtivo(_ativoUsuario);
            _ativoUsuario.Usuario.AtivosUsuario.Should().Contain(_ativoUsuario);
        }

        [Fact]
        public async Task ComprarAtivoAsync_DeveAtualizarAtivoDoUsuario()
        {
            _ativoUsuario.Usuario.AtivosUsuario = null;
            await _ativoUsuarioDomainService.ComprarAtivo(_ativoUsuario);
            _ativoUsuario.Usuario.AtivosUsuario.Should().NotBeNullOrEmpty();
        }

        [Fact]
        public async Task ComprarAtivoAsync_DeveDebitarSaldoContaCorrente()
        {
            await _ativoUsuarioDomainService.ComprarAtivo(_ativoUsuario);
            _ativoUsuario.Usuario.ContaCorrente.Saldo.Should().Be(150);
        }

        [Fact]
        public async Task ComprarAtivoAsync_DeveAtualizarNumeroVendasAtivo()
        {            
            await _ativoUsuarioDomainService.ComprarAtivo(_ativoUsuario);
            _ativoUsuario.Ativo.QuantidadeNegociados.Should().BeGreaterThan(0);
        }

        [Fact]
        public async Task ComprarAtivoAsync_DeveGerarExcecaoSaldoInsuficiente()
        {
            _ativoUsuario.Usuario.ContaCorrente.Saldo = 0;

            Func<Task> action = () => _ativoUsuarioDomainService.ComprarAtivo(_ativoUsuario);
            await action.Should().ThrowAsync<Exception>();
        }
    }
}