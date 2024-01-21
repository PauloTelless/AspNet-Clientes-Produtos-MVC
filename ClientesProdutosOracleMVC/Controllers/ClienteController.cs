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
        var clientes = _clienteRepository.ListarClientes().OrderBy(x => x.Nome);

        return View(clientes);
    }

    public IActionResult CriarCliente()
    {
        return View();
    }

    public IActionResult EditarCliente(int id)
    {
        Cliente clienteEncontrado = _clienteRepository.EncontrarIdCliente(id);
        
        return View(clienteEncontrado);
    }

    public IActionResult DeletarCliente(int id)
    {
        Cliente cliente = _clienteRepository.EncontrarIdCliente(id);

        return View(cliente);
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

    [HttpPost]
    public IActionResult PutCliente(Cliente cliente)
    {
        _clienteRepository.EditarCliente(cliente);

        return RedirectToAction("Index");
    }

    public IActionResult DeleteCliente(int id)
    {
        _clienteRepository.DeletarCliente(id);

        return RedirectToAction("Index");
    }
}
