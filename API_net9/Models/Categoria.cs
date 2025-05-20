using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace API_net9.Models;

public class Categoria
{
    public Categoria()
    {
        Produtos = new Collection<Produto>();
    }
    [Key]
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]
    public string Nome { get; set; }
    [Required]
    [StringLength(200)]
    public string ImagemUrl { get; set; }

    // Dessa forma abaixo estamos criando uma relação da tabela categoria com a produtos, como se fosse uma chave estrangeira
    public ICollection<Produto> Produtos { get; set; }
}
