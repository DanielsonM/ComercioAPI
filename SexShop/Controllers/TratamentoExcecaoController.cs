using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace SexShop.Controllers
{
    [ApiExplorerSettings(IgnoreApi = true)]
    public class TratamentoExcecaoController : ControllerBase
    {
        [Route("*/Error")]
        public IActionResult identificadorDeErro() =>
            Problem();

        [Route("*/error-development")]
        public IActionResult identificadorErroDesenvolvimento([FromServices] IHostEnvironment ambienteHost)
        {
            if (ambienteHost.IsDevelopment())
                return NotFound();

            var manipuladorDeExcecao = HttpContext.Features.Get<IExceptionHandlerFeature>();

            return Problem(detail: manipuladorDeExcecao.Error.StackTrace, title: manipuladorDeExcecao.Error.Message);
                
        }
    }
}
