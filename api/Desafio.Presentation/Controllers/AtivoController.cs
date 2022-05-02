using Desafio.Application.Contracts;
using Desafio.Application.Exceptions;
using Desafio.Application.Extensions;
using Desafio.Application.Models.Ativos;
using Desafio.Application.Models.Shared;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Desafio.Presentation.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> GetAsync()
        {
            try
            {
                var ativos = await _ativoApplicationService.ObterCincoAtivosMaisNegociados();
                return Ok(new ResultModel<List<AtivoModel>>(ativos));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultModel<List<AtivoModel>>($"JUW1523 - {ex.Message}"));
            }
        }

        [HttpPost]
        [Route("order")]
        public async Task<IActionResult> PostAsync([FromBody] ComprarAtivoModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultModel<string>(ModelState.GetErrors()));

            try
            { 
                await _ativoApplicationService.ValidarAtivo(model.AtivoId);
                await _usuarioApplicationService.ValidarUsuario(model.UsuarioId);
                await _ativoApplicationService.ComprarAtivo(model);

                return Ok(new ResultModel<string>("Compra de ativo realizada com sucesso!", null));
            }
            catch (UsuarioInvalidoException ex)
            {
                return BadRequest(new ResultModel<string>($"MZV0565 - {ex.Message}"));
            }
            catch (AtivoInvalidoException ex)
            {
                return BadRequest(new ResultModel<string>($"MYH5152 - {ex.Message}"));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultModel<string>($"JEM4721 - {ex.Message}"));
            }
        }
    }
}