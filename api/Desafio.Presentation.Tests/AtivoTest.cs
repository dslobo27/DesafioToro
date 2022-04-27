using AutoFixture;
using Desafio.Application.Contracts;
using Desafio.Application.Exceptions;
using Desafio.Application.Models.Ativos;
using Desafio.Application.Models.Shared;
using Desafio.Presentation.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.Presentation.Tests
{
    public class AtivoTest
    {
        private readonly Mock<IAtivoApplicationService> _ativoApplicationServiceMock = new();
        private readonly Mock<IUsuarioApplicationService> _usuarioApplicationServiceMock = new();

        public AtivoController _ativoController;
        public List<AtivoModel> _listaAtivos;
        public ComprarAtivoModel _comprarAtivoModel;

        public AtivoTest()
        {
            _ativoController = new AtivoController(_ativoApplicationServiceMock.Object, _usuarioApplicationServiceMock.Object);

            var fixture = new Fixture();
            _listaAtivos = fixture.Create<List<AtivoModel>>();
            _comprarAtivoModel = fixture.Create<ComprarAtivoModel>();
        }

        [Fact]
        public async Task GetAsync_DeveRetornarOk()
        {
            _ativoApplicationServiceMock.Setup(a => a.ObterCincoAtivosMaisNegociados())
                .Returns(Task.FromResult(_listaAtivos));
            var lista = new ResultModel<List<AtivoModel>>(_listaAtivos);

            var result = (ObjectResult)await _ativoController.GetAsync();

            _ativoApplicationServiceMock.Verify(a => a.ObterCincoAtivosMaisNegociados(), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(lista);
        }

        [Fact]
        public async Task GetAsync_DeveRetornarException()
        {
            _ativoApplicationServiceMock.Setup(a => a.ObterCincoAtivosMaisNegociados()).Throws(new Exception());

            var result = (ObjectResult)await _ativoController.GetAsync();

            _ativoApplicationServiceMock.Verify(a => a.ObterCincoAtivosMaisNegociados(), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }

        [Fact]
        public async Task PostAsync_DeveRetornarOk()
        {
            _ativoApplicationServiceMock.Setup(a => a.ComprarAtivo(_comprarAtivoModel)).Returns(Task.CompletedTask);

            var result = (ObjectResult)await _ativoController.PostAsync(_comprarAtivoModel);

            _ativoApplicationServiceMock.Verify(a => a.ComprarAtivo(_comprarAtivoModel), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
        }

        [Fact]
        public async Task PostAsync_DeveRetornarException()
        {
            _ativoApplicationServiceMock.Setup(a => a.ComprarAtivo(_comprarAtivoModel)).Throws(new Exception());

            var result = (ObjectResult)await _ativoController.PostAsync(_comprarAtivoModel);

            _ativoApplicationServiceMock.Verify(a => a.ComprarAtivo(_comprarAtivoModel), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}