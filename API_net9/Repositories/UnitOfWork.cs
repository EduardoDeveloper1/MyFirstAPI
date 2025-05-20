using API_net9.Context;

namespace API_net9.Repositories;

public class UnitOfWork : IUnitOfWork
{
    private IProdutoRepository _produtoRepository;

    private ICategoriaRepository _categoriaRepository;
    public AppDbContext _context;

    public UnitOfWork(AppDbContext context)
    {
        _context = context;
    }

    public IProdutoRepository ProdutoRepository
    {
        get
        {
            //Verifica se a instancia existe e caso n, cria uma nova
            return _produtoRepository = _produtoRepository ?? new ProdutoRepository(_context);
        }
    }

    public ICategoriaRepository CategoriaRepository
    {
        get
        {
            //Verifica se a instancia existe e caso n, cria uma nova
            return _categoriaRepository = _categoriaRepository ?? new CategoriaRepository(_context);
        }
    }

    public void Commit()
    {
        _context.SaveChanges();
    }

    public void Dispose()
    {
        _context.Dispose();
    }
}
