using API_net9.Context;
using API_net9.Models;
using Microsoft.EntityFrameworkCore;

namespace API_net9.Repositories;

public class CategoriaRepository : ICategoriaRepository
{

    private readonly AppDbContext _context;

    public CategoriaRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<Categoria> GetAllCategorias()
    {
        return _context.Categorias.ToList();
    }

    public Categoria GetCategoriaId(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
        return categoria;
    }

    public Categoria Create(Categoria categoria)
    {
        if (categoria is null)
        {
            throw new ArgumentNullException(nameof(categoria));
        }

        _context.Categorias.Add(categoria);// inclui no contexto

        return categoria;
    }

    public Categoria Update(Categoria categoria)
    {
        if (categoria is null)
        {
            throw new ArgumentNullException(nameof(categoria));
        }
        _context.Entry(categoria).State = EntityState.Modified;

        return categoria;
    }

    public Categoria Delete(int id)
    {
        var categoria = _context.Categorias.FirstOrDefault(p => p.CategoriaId == id);
        if (categoria is null)
        {
            throw new ArgumentNullException(nameof(categoria));
        }
        _context.Remove(id);

        return categoria;

    }
}
