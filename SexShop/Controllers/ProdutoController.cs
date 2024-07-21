using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Comercio.Aplicacao.Serviços.ViewModel;
using Comercio.Dominio.Model;

namespace Comercio.Controllers
{
    [ApiController]
    [Route("api/Comercio")]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoRepositorio _iProduto;
        private readonly ILogger<Produto> _logger;

        public ProdutoController(IProdutoRepositorio iProduto, ILogger<Produto> logger)
        {
            _iProduto = iProduto ?? throw new ArgumentNullException(nameof(iProduto));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }



        //[Authorize]
        [HttpGet]
        public IActionResult Get(int intNumeroPagina, int intQuantidade)
        {
            this._logger.Log(LogLevel.Error, "Error");

            var produto = this._iProduto.Get(intNumeroPagina, intQuantidade);
            return Ok(produto); 
        }
        
        //[Authorize]
        [HttpPost]
        public IActionResult Add([FromForm] ProdutoViewModel viewProduto)
        {

            var filePath = Path.Combine("Storage", viewProduto.Imagem.FileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                viewProduto.Imagem.CopyTo(fileStream);
            }

            var produto = new Produto(viewProduto.intId, viewProduto.strNome, viewProduto.strCategoria, viewProduto.strDescricao, viewProduto.decValor, filePath);

            this._iProduto.Add(produto);

            return Ok();
        }

        //[Authorize]
        [HttpPost]
        [Route("image/download")]
        public IActionResult baixarImagem(int intId)
        {
            var produto = this._iProduto.Get(intId);

            var dataBytes = System.IO.File.ReadAllBytes(produto.strImagem);

            return File(dataBytes, "image/jpg");
        }
    }
}
