using API_net9.Context;
using API_net9.Models;
using API_net9.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_net9.Controllers;

[Route("[controller]")]
[ApiController]
public class CategoriasController : ControllerBase
{
    private readonly ICategoriaRepository _repository;
    public CategoriasController(ICategoriaRepository repository)
    {
        _repository = repository;
    }

    //[HttpGet("produtos")]
    //public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    //{
    //    return;
    //}

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetAll()
    {
        var categorias = _repository.GetAllCategorias();
        return Ok(categorias);
    }

    [HttpGet("{id:int:min(1)}", Name = "Obter categoria")]
    public ActionResult<Categoria> GetForId(int id)
    {
        var categoria = _repository.GetCategoriaId(id);
        return Ok(categoria);
    }

    [HttpPost]
    //cria ou altera uma categoria existente
    public ActionResult Post(Categoria categoria)
    {
        if (categoria is null)
        {
            return BadRequest();
        }

        _repository.Create(categoria);// inclui no contexto

        return new CreatedAtRouteResult("Obter categoria", new { id = categoria.CategoriaId }, categoria);
    }

    [HttpPut("{id:int}")]
    // método para alterar um produto existente
    public ActionResult Put(int id, Categoria categoria)
    {
        if (id != categoria.CategoriaId)
        {
            return BadRequest();
        }

        _repository.Update(categoria);

        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _repository.GetCategoriaId(id);// localiza o produto no banco de dados
        if (categoria is null)
        {
            return NotFound();
        }

        _repository.Delete(id);
        return Ok(categoria);
    }
}
