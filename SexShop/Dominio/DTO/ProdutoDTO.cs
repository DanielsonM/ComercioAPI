namespace Comercio.Dominio.DTO
{
    public class ProdutoDTO
    {
        public int intId { get;  set; }
        public string? strNome { get;  set; }
        public string? strCategoria { get;  set; }
        public string? strDescricao { get; set; }
        public decimal decValor { get;  set; }
        public string? strImagem { get; set; }
    }
}
