using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;

namespace ClientesProdutosOracleMVC.Controllers;

public class ProdutoController : Controller
{
    private readonly ICliente _clienteRepository;
    private readonly IProduto _produtoRepository;
    public ProdutoController(ICliente clienteRepository, IProduto produtoRepository)
    {
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
    }
    public IActionResult Index()
    {
        return View();
    }

    public IActionResult CriarProduto()
    {
        return View();
    }

    [HttpPost]
    public IActionResult PostProduto(int clienteId,Produto produto)
    {

        _produtoRepository.AdicionarProduto(clienteId, produto);

        return RedirectToAction("ListarProdutos", "Cliente");
    }
}
