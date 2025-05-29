using System.ComponentModel.DataAnnotations;

namespace API_net9.DTOs;

public class CategoriaDTO
{
    public int CategoriaId { get; set; }
    [Required]
    [StringLength(80)]
    public string Nome { get; set; }
    [Required]
    [StringLength(200)]
    public string ImagemUrl { get; set; }

}
