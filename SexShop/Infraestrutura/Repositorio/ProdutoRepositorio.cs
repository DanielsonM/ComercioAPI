using Comercio.Dominio.DTO;
using Comercio.Dominio.Model;

namespace Comercio.Infraestrutura.Repositorio
{
    public class ProdutoRepositorio : IProdutoRepositorio
    {
        public readonly DbConexao _dbContex = new DbConexao();
        public void Add(Produto produto)
        {
            _dbContex.Add(produto);
            _dbContex.SaveChanges();
        }

        public List<ProdutoDTO> Get(int intNumeroPagina, int intQuantidade)
        {
            return _dbContex.Produtos.Skip(intNumeroPagina * intQuantidade).Take(intQuantidade).Select(
                b =>
                new ProdutoDTO()
                {
                   intId =  b.intId,
                   strNome = b.strNome,
                   strCategoria = b.strCategoria,
                   strDescricao = b.strDescricao,
                   decValor = b.decValor,
                   strImagem = b.strImagem,
                }).ToList();
        }

        public Produto Get(int id)
        {
           
            return _dbContex.Produtos.Find(id);
        }
    }
}
