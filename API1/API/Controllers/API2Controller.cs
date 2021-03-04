using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace API.Controllers
{
    public class API2Controller : Controller
    {
        private readonly IAppServiceJuro _servicoAplicacao;

        public API2Controller(IAppServiceJuro servicoAplicacao)
        {
            _servicoAplicacao = servicoAplicacao;
        }

        [HttpGet("taxaJuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult taxaJuro()
        {
            try
            {
                return Ok(_servicoAplicacao.GetJuro().Taxa);
            }
            catch (Exception ex)
            {
                return BadRequest(error: ex.Message);
            }
        }

    }
}