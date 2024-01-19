using ClientesProdutosOracleMVC.Models;

namespace ClientesProdutosOracleMVC.Repositories.Interfaces;

public interface ICliente
{
    Cliente AdicionarCliente(Cliente cliente);
    Cliente EncontrarIdCliente(int id);
    IEnumerable<Cliente> ListarClientes();
}
