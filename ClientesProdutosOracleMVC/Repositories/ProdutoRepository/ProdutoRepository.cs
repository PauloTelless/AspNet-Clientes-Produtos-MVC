﻿using ClientesProdutosOracleMVC.Context;
using ClientesProdutosOracleMVC.Models;
using ClientesProdutosOracleMVC.Repositories.Interfaces;

namespace ClientesProdutosOracleMVC.Repositories.ProdutoRepository;

public class ProdutoRepository : IProduto
{
    private readonly AppDbContext _context;
    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public Produto AdicionarProduto(int Clienteid, Produto produto)
    {
        produto.ClienteId = Clienteid;

        _context.Add(produto);

        _context.SaveChanges();

        return produto;
    }

    public bool DeletarProduto(int id)
    {
        var produtoId = EncontradIdProduto(id);

        _context.Produtos.Remove(produtoId);    

        _context.SaveChanges();

        return true;
    }

    public Produto EditarProduto(Produto produto)
    {

        Produto produtoDb = EncontradIdProduto(produto.ProdutoId);

        produtoDb.NomeProduto = produto.NomeProduto;
        produtoDb.Categoria = produto.Categoria;
        produtoDb.PrecoProduto = produto.PrecoProduto;
        produtoDb.DescricaoProduto = produto.DescricaoProduto;

        _context.Update(produtoDb);

        _context.SaveChanges();

        return produtoDb;
    }

    public Produto EncontradIdProduto(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(x => x.ProdutoId == id);

        return produto;
    }

    public IEnumerable<Produto> ObterProdutosDoCliente(int id)
    {
        return _context.Produtos
            .Where(x => x.ClienteId == id)
            .ToList().OrderBy(x => x.NomeProduto);
    }

}
