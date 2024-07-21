namespace Comercio.Aplicacao.Serviços.ViewModel
{
    public class ProdutoViewModel
    {
        public int intId { get; set; }

        public string strNome { get; set; }

        public string strCategoria { get; set; }
        public string strDescricao { get; set; }

        public decimal decValor { get; set; }

        public IFormFile Imagem { get; set; }
    }
}
