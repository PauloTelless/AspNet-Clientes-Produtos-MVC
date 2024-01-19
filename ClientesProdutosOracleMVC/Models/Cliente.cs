using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Net;

namespace ClientesProdutosOracleMVC.Models;

[Table("Clientes")]
public class Cliente
{
    public Cliente()
    {
        Produtos = new Collection<Produto>();  
    }

    [Key]
    public int ClienteId { get; set; }

    [Required, StringLength(80, MinimumLength =10, ErrorMessage ="O nome deve conter 80 caracteres no máximo ou, no mínimo, 10 caracteres")]
    public string Nome { get; set; }

    [Required, StringLength(30, MinimumLength = 10, ErrorMessage = "O nome de usuário deve conter, no máximo, 30 caracteres ou, no mínimo, 5 caracteres")]
    public string NomeUsuario { get; set; }

    [Required, StringLength(80)]
    public string Email { get; set; }

    [Required, StringLength(11)]
    public string Contato{ get; set; }

    public Collection<Produto> Produtos { get; set; }
}
