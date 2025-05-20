using API_net9.Models;

namespace API_net9.Repositories;

public interface IProdutoRepository
{
    IEnumerable<Produto> GetAllProdutos();
    Produto GetProdutoId(int id);
    Produto Create(Produto produto);
    Produto Update(Produto produto);
    Produto Delete(int id);

}
