using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientesProdutosOracleMVC.Controllers;

public class ProdutoController : Controller
{
    private readonly IProduto _produtoRepositorio;
    public ProdutoController(IProduto produtoRepositorio)
    {
        _produtoRepositorio = produtoRepositorio;
    }
    public IActionResult Index()
    {

        return View();
    }

    public IActionResult CriarProduto(int id)
    {
        ViewBag.ClienteId = id;

        return View();
    }

    [HttpPost]
    public IActionResult PostProduto(int Clienteid, Produto produto)
    {
        _produtoRepositorio.AdicionarProduto(Clienteid, produto);

        return RedirectToAction("Index", "Cliente");
    }

}
