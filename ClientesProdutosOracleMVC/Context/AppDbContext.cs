using ClientesProdutosOracleMVC.Models;
using Microsoft.EntityFrameworkCore;

namespace ClientesProdutosOracleMVC.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions options) : base(options)
    {}

    public DbSet<Cliente> Clientes { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
