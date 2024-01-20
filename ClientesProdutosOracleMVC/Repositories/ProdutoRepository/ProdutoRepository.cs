using ClientesProdutosOracleMVC.Context;
using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;

namespace ClientesProdutosOracleMVC.Repositories.ProdutoRepository;

public class ProdutoRepository : IProduto
{
    private readonly ICliente _clienteRepositorio;
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context, ICliente clienteRepositorio)
    {
        _context = context;
        _clienteRepositorio = clienteRepositorio;
    }
    public IEnumerable<Produto> ObterProdutosDoCliente(int id)
    {
        return _context.Produtos
            .Where(x => x.ClienteId == id)
            .ToList();
    }
    public Produto AdicionarProduto(int clienteid, Produto produto)
    {
        var cliente = _clienteRepositorio.EncontrarIdCliente(clienteid);

        var id = _context.Produtos.Where(x => x.ClienteId == cliente.ClienteId);

        return produto;
    }
}
