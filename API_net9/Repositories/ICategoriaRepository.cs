using API_net9.Models;

namespace API_net9.Repositories;

public interface ICategoriaRepository 
{
    IEnumerable<Categoria> GetAllCategorias();
    Categoria GetCategoriaId(int id);
    Categoria Create(Categoria categoria);
    Categoria Update(Categoria categoria);
    Categoria Delete(int id);

}

