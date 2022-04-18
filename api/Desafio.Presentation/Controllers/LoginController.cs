using Desafio.Application.Contracts;
using Desafio.Application.Extensions;
using Desafio.Application.Models.Shared;
using Desafio.Application.Models.Usuarios;
using Desafio.Presentation.Authorization;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace Desafio.Presentation.Controllers
{
    [AllowAnonymous]
    [Route("api/login")]
    [ApiController]
    public class LoginController : Controller
    {
        private readonly TokenService _tokenService;
        private readonly IUsuarioApplicationService _usuarioApplicationService;

        public LoginController(TokenService tokenService, IUsuarioApplicationService usuarioApplicationService)
        {
            _tokenService = tokenService;
            _usuarioApplicationService = usuarioApplicationService;
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid)
                return BadRequest(new ResultModel<string>(ModelState.GetErrors()));

            try
            {
                var user = await _usuarioApplicationService.Login(model.Cpf, model.Senha);

                if (user == null)
                    return StatusCode(401, new ResultModel<string>("Usuário ou senha inválidos."));

                var token = _tokenService.GerarToken(user);
                return Ok(new ResultModel<string>(token, null));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new ResultModel<string>($"HJY4781 - {ex.Message}"));
            }
        }
    }
}