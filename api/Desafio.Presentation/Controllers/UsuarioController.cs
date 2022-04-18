using Desafio.Application.Contracts;
using Desafio.Application.Models.Shared;
using Desafio.Application.Models.Usuarios;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Desafio.Presentation.Controllers
{
    [Authorize]
    [ApiController]
    [Route("api/users")]
    public class UsuarioController : Controller
    {
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public UsuarioController(IUsuarioApplicationService usuarioApplicationService)
        {
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAsync([FromQuery] Guid usuarioId)
        {
            try
            {
                var usuario = await _usuarioApplicationService.ObterPorId(usuarioId);
                return Ok(new ResultModel<UsuarioModel>(usuario));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultModel<UsuarioModel>($"HTN2235 - {ex.Message}"));
            }
        }
    }
}