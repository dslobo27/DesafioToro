using Desafio.Application.Contracts;
using Desafio.Application.Exceptions;
using Desafio.Application.Models.Ativos;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio.Presentation.Controllers
{
    [Route("api/assets")]
    [ApiController]
    public class AtivoController : Controller
    {
        private readonly IAtivoApplicationService _ativoApplicationService;
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public AtivoController(IAtivoApplicationService ativoApplicationService, IUsuarioApplicationService usuarioApplicationService)
        {
            _ativoApplicationService = ativoApplicationService;
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpGet]
        [Route("trends")]
        public IActionResult Get()
        {
            try
            {
                var ativos = _ativoApplicationService.ObterCincoAtivosMaisNegociados();

                if (ativos != null && ativos.Count > 0)
                    return Ok(ativos);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }

        [HttpPost]
        [Route("order")]
        public IActionResult Post(ComprarAtivoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            try
            {
                _ativoApplicationService.ValidarAtivo(model.AtivoId);
                _usuarioApplicationService.ValidarUsuario(model.UsuarioId);
                _ativoApplicationService.ComprarAtivo(model);

                return Ok();
            }
            catch (UsuarioInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (AtivoInvalidoException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}