using ClientesProdutosOracleMVC.Context;
using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;

namespace ClientesProdutosOracleMVC.Repositories.ProdutoRepository;

public class ProdutoRepository : IProduto
{
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public Produto AdicionarProduto(int Clienteid, Produto produto)
    {
        produto.ClienteId = Clienteid;

        _context.Add(produto);

        _context.SaveChanges();

        return produto;
    }

    public IEnumerable<Produto> ObterProdutosDoCliente(int id)
    {
        return _context.Produtos
            .Where(x => x.ClienteId == id)
            .ToList();
    }

    public Produto EncontrarIdClienteProduto(int id)
    {
        var clienteProdutoId = _context.Produtos.FirstOrDefault(x => x.ClienteId == id);

        return clienteProdutoId;
    }
}
