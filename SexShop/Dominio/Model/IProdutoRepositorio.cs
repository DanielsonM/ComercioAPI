using Comercio.Dominio.DTO;

namespace Comercio.Dominio.Model
{
    public interface IProdutoRepositorio
    {
        void Add(Produto objProduto);

        List<ProdutoDTO> Get(int intNumeroPagina, int intQuantidade);

        Produto Get(int id);
    }
}
