using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClientesProdutosOracleMVC.Models;

[Table("Produtos")]
public class Produto
{
    [Key]
    public int ProdutoId { get; set; }

    [Required, StringLength(80, MinimumLength =10, ErrorMessage ="O produto só pode conter até 80 caracteres ou, no mínimo, 10")]
    public string NomeProduto { get; set; }

    [Required, StringLength(50, MinimumLength =10, ErrorMessage ="O categoria deve conter até 50 caracteres ou, no mínimo, 10")]
    public string Categoria { get; set; }

    [Required, Column(TypeName ="decimal(10,2)")]
    public decimal PrecoProduto { get; set; }

    [Required, StringLength(300, MinimumLength = 10, ErrorMessage ="A descrição deve estar entre um intervalo de 10 a 300 caracteres")]
    public string DescricaoProduto { get; set; }


    public int ClienteId { get; set; }
    public Cliente Clientes { get; set; }

}
