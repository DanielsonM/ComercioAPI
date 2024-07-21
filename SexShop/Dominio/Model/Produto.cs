using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Comercio.Dominio.Model
{
    [Table("produto")]
    public class Produto
    {

        [Key]
        public int intId { get;  private set; }
        public string strNome { get;  private set; }
        public string strCategoria { get;  private set; }
        public string strDescricao { get;  private set; }
        public decimal decValor { get;  private set; }
        public string? strImagem { get; private set; }

        public Produto()
        {

        }
        public Produto(int intId, string strNome, string strCategoria, string strDescricao, decimal decValor, string? strImagem)
        {
            this.intId = intId;
            this.strNome = strNome ?? throw new ArgumentNullException(nameof(strNome));
            this.strCategoria = strCategoria;
            this.strDescricao = strDescricao;
            this.decValor = decValor;
            this.strImagem = strImagem;
        }
    }
}
