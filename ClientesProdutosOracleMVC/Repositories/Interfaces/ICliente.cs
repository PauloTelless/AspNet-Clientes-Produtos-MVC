using ClientesProdutosOracleMVC.Models;

namespace ClientesProdutosOracleMVC.Repositories.Interfaces;

public interface ICliente
{
    Cliente AdicionarCliente(Cliente cliente);
    IEnumerable<Cliente> ListarClientes();
}
