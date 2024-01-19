using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;
using ClientesProdutosOracleMVC.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace ClientesProdutosOracleMVC.Controllers;

public class ClienteController : Controller
{
    private readonly ICliente _clienteRepository;
    private readonly IProduto _produtoRepository;
    public ClienteController(ICliente clienteRepository, IProduto produtoRepository)
    {
        _clienteRepository = clienteRepository;
        _produtoRepository = produtoRepository;
    }
    public IActionResult Index()
    {
        var clientes = _clienteRepository.ListarClientes();

        return View(clientes);
    }

    public IActionResult CriarCliente()
    {
        return View();
    }

    public IActionResult ListarProdutos(int id)
    {
        var cliente = _clienteRepository.EncontrarIdCliente(id);

        var produtos = _produtoRepository.ObterProdutosDoCliente(id);

        List<ClienteProdutoViewModel> viewModelList = new List<ClienteProdutoViewModel>
    {
            new ClienteProdutoViewModel
            {
                Cliente = cliente,
                Produtos = produtos
            },
    };

        return View(viewModelList);

    }

    [HttpPost]
    public IActionResult PostCliente(Cliente cliente)
    {
        _clienteRepository.AdicionarCliente(cliente);

        return RedirectToAction("Index");
    }
}
