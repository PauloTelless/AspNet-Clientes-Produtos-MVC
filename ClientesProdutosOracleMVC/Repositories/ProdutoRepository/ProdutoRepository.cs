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

    public IEnumerable<Produto> ObterProdutosDoCliente(int id)
    {
        return _context.Produtos
            .Where(x => x.ClienteId == id)
            .ToList();
    }


}
