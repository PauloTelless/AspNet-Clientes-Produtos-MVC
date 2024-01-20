using ClientesProdutosOracleMVC.Models;

namespace ClientesProdutosOracleMVC.Repositories.Interfaces;

public interface IProduto
{
    IEnumerable<Produto> ObterProdutosDoCliente(int id);
    Produto AdicionarProduto(int Clienteid, Produto produto);
    Produto EncontradIdProduto(int id);
    Produto EditarProduto(Produto produto);
    bool DeletarProduto(int id);
}
