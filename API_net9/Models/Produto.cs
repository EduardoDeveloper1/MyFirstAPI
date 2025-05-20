using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API_net9.Models;

public class Produto
{
    [Key]
    public int ProdutoId { get; set; }
    [Required]
    [StringLength(80)]
    public string NomeProduto { get; set; }
    [Required]
    [StringLength(300)]
    public string Descricao { get; set; }
    [Required]
    [Column(TypeName = "decimal(10,2)")]
    public decimal Preco { get; set; }
    [Required]
    [StringLength(300)]
    public string ImagemUrlProduto { get; set; }
    public float Estoque { get; set; }
    public DateTime DataCadastro { get; set; }

    //Criando o relacionamento com a tabela categoria
    public int CategoriaId { get; set; }
    public Categoria Categoria { get; set; }
}
