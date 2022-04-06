using Desafio.Application.Contracts;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Desafio.Presentation.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AtivoController : Controller
    {
        private readonly IAtivoApplicationService _applicationService;

        public AtivoController(IAtivoApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpGet]
        [Route("trends")]
        public IActionResult Get()
        {
            try
            {
                var ativos = _applicationService.ObterCincoAtivosMaisNegociados();

                if (ativos != null && ativos.Count > 0)
                    return Ok(ativos);

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
    }
}