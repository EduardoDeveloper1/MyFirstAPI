using API_net9.Models;
using Microsoft.EntityFrameworkCore;

namespace API_net9.Context;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base (options)
    {
        
    }

    //Abaixo está informando que as classes categoria e produto serão mapeadas para o banco com os nomes categorias e produtos
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Produto> Produtos { get; set; }
}
