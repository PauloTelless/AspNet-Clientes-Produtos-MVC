using ClientesProdutosOracleMVC.Models;

namespace ClientesProdutosOracleMVC.Repositories.Interfaces;

public interface IProduto
{
    IEnumerable<Produto> ObterProdutosDoCliente(int id);
    Produto AdicionarProduto(int clienteId, Produto produto);
}
