using AutoFixture;
using Desafio.Application.Contracts;
using Desafio.Application.Models.Shared;
using Desafio.Application.Models.Usuarios;
using Desafio.Presentation.Controllers;
using FluentAssertions;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace Desafio.Presentation.Tests
{
    public class UsuarioTest
    {
        private readonly Mock<IUsuarioApplicationService> _usuarioApplicationServiceMock = new();

        public UsuarioController _usuarioController;
        public UsuarioModel _usuarioModel;

        public UsuarioTest()
        {
            _usuarioController = new UsuarioController(_usuarioApplicationServiceMock.Object);

            var fixture = new Fixture();
            _usuarioModel = fixture.Create<UsuarioModel>();
            _usuarioModel.Id = Guid.Parse("1c52dede-ef5d-4b86-ba24-a80b1e69f0e6");
            _usuarioModel.Nome = "Cesar Tralli";
        }

        [Theory]
        [InlineData("1c52dede-ef5d-4b86-ba24-a80b1e69f0e6")]
        public async Task GetAsync_DeveRetornarOk(Guid usuarioId)
        {
            _usuarioApplicationServiceMock.Setup(u => u.ObterPorId(It.IsAny<Guid>()))
                .Returns(Task.FromResult(_usuarioModel));

            var usuarioModel = new ResultModel<UsuarioModel>(_usuarioModel);

            var result = (ObjectResult)await _usuarioController.GetAsync(usuarioId);

            _usuarioApplicationServiceMock.Verify(u => u.ObterPorId(usuarioId), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status200OK);
            result.Value.Should().BeEquivalentTo(usuarioModel);
        }

        [Theory]
        [InlineData("1c52dede-ef5d-4b86-ba24-a80b1e69f0e6")]
        public async Task GetAsync_DeveRetornarException(Guid usuarioId)
        {
            _usuarioApplicationServiceMock.Setup(u => u.ObterPorId(It.IsAny<Guid>())).Throws(new Exception());

            var result = (ObjectResult)await _usuarioController.GetAsync(usuarioId);

            _usuarioApplicationServiceMock.Verify(u => u.ObterPorId(usuarioId), Times.Once);
            result.StatusCode.Should().Be(StatusCodes.Status500InternalServerError);
        }
    }
}
