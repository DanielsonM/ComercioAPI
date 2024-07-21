using Microsoft.AspNetCore.Mvc;
using Comercio.Aplicacao.Serviços;
using Comercio.Dominio.Model;

namespace SexShop.Controllers
{
    [ApiController]
    [Route("api/v1/auth")]
    public class AuthController : Controller
    {
        [HttpPost]
        public IActionResult Auth(string username, string password)
        {
            if(username == "danielson" || password == "lineage2pan")
            {
                var chave = ServicoDeTokens.GerarToken(new Produto());

                return Ok(chave);
            }

            return BadRequest("Nome ou senha inválido");
        }
    }
}
