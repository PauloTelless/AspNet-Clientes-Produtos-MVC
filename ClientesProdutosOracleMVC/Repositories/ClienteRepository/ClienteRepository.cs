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

    public bool DeletarCliente(int id)
    {
        Cliente cliente = EncontrarIdCliente(id);

        _context.Clientes.Remove(cliente);

        _context.SaveChanges();

        return true;
    }

    public Cliente EditarCliente(Cliente cliente)
    {
        var clienteid = EncontrarIdCliente(cliente.ClienteId);

        clienteid.Nome = cliente.Nome;
        clienteid.NomeUsuario= cliente.NomeUsuario;
        clienteid.Email = cliente.Email;
        clienteid.Contato = cliente.Contato;

        _context.Update(clienteid);

        _context.SaveChanges();

        return clienteid;
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
