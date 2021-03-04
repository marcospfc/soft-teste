using Application.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Threading.Tasks;

namespace API.Controllers
{
    public class API1Controller : Controller
    {
        private readonly IAppServiceCalc _servicoAplicacao;

        public API1Controller(IAppServiceCalc servicoAplicacao)
        {
            _servicoAplicacao = servicoAplicacao;
        }

        [HttpGet("calculajuros")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> calculajurosAsync([FromQuery][BindRequired] decimal valorInicial, [FromQuery][BindRequired] int tempo)
        {
            var calculo = await _servicoAplicacao.GetCalculoAsync(valorInicial, tempo);

            if (!_servicoAplicacao.GetNotification().IsValid())
                return BadRequest(error: _servicoAplicacao.GetNotification().returnError());

            return Ok(calculo);
        }

        [HttpGet("showmethecode")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> showmethecode()
        {
            return Ok("https://github.com/marcospfc/soft-teste.git");
        }
    }
}