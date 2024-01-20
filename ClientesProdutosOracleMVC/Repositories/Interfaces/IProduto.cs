using ClientesProdutosOracleMVC.Models;

namespace ClientesProdutosOracleMVC.Repositories.Interfaces;

public interface IProduto
{
    IEnumerable<Produto> ObterProdutosDoCliente(int id);
    Produto AdicionarProduto(int id,Produto produto);
    Produto EncontrarIdClienteProduto(int id);
}
