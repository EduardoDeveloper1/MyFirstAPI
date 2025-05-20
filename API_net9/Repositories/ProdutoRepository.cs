using API_net9.Context;
using API_net9.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NuGet.Protocol.Core.Types;

namespace API_net9.Repositories;

public class ProdutoRepository : IProdutoRepository
{
    private readonly AppDbContext _context;

    public ProdutoRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Produto> GetAllProdutos()
    {
        return _context.Produtos.ToList();
    }
    public Produto GetProdutoId(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        return produto;
    }
    public Produto Create(Produto produto)
    {
        if (produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }

        _context.Produtos.Add(produto);// inclui no contexto
        _context.SaveChanges();

        return produto;
    }
    public Produto Update(Produto produto)
    {
        if(produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }
        _context.Entry(produto).State = EntityState.Modified;
        _context.SaveChanges();
        return produto;
    }
    public Produto Delete(int id)
    {
        var produto = _context.Produtos.FirstOrDefault(p => p.ProdutoId == id);
        if (produto is null)
        {
            throw new ArgumentNullException(nameof(produto));
        }
        _context.Remove(id);
        _context.SaveChanges();

        return produto;
    }
}
