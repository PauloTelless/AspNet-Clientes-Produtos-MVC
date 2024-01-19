using ClientesProdutosOracleMVC.Models;

namespace ClientesProdutosOracleMVC.ViewModels;

public class ClienteProdutoViewModel
{
    public Cliente Cliente { get; set; }
    public IEnumerable<Produto> Produtos { get; set; }
}
