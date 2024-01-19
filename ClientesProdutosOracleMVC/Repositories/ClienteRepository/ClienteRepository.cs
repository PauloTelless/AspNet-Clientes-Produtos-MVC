using ClientesProdutosOracleMVC.Context;
using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;

namespace ClientesProdutosOracleMVC.Repositories.ClienteRepository;

public class ClienteRepository : ICliente
{
    private readonly AppDbContext _context;
    public ClienteRepository(AppDbContext context)
    {
        _context = context;
    }

    public Cliente AdicionarCliente(Cliente cliente)
    {
        _context.Clientes.Add(cliente);

        _context.SaveChanges();

        return cliente;
    }

    public Cliente EncontrarIdCliente(int id)
    {
        var clienteId = _context.Clientes.FirstOrDefault(x => x.ClienteId == id);

        return clienteId;
    }

    IEnumerable<Cliente> ICliente.ListarClientes()
    {
        var clientes = _context.Clientes.ToList();

        return clientes;
    }
}
