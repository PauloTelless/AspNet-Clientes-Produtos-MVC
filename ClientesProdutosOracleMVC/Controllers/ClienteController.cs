using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace ClientesProdutosOracleMVC.Controllers;

public class ClienteController : Controller
{
    private readonly ICliente _clienteRepository;
    public ClienteController(ICliente clienteRepository)
    {
        _clienteRepository = clienteRepository;
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

    [HttpPost]
    public IActionResult PostCliente(Cliente cliente)
    {
        _clienteRepository.AdicionarCliente(cliente);

        return RedirectToAction("Index");
    }
}
