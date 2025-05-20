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
    private readonly IUnitOfWork _unitOfWork;
    public CategoriasController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    //[HttpGet("produtos")]
    //public ActionResult<IEnumerable<Categoria>> GetCategoriasProdutos()
    //{
    //    return;
    //}

    [HttpGet]
    public ActionResult<IEnumerable<Categoria>> GetAll()
    {
        var categorias = _unitOfWork.CategoriaRepository.GetAllCategorias();
        return Ok(categorias);
    }

    [HttpGet("{id:int:min(1)}", Name = "Obter categoria")]
    public ActionResult<Categoria> GetForId(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.GetCategoriaId(id);
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

        _unitOfWork.CategoriaRepository.Create(categoria);// inclui no contexto
        _unitOfWork.Commit();

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

        _unitOfWork.CategoriaRepository.Update(categoria);
        _unitOfWork.Commit();

        return Ok(categoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult Delete(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.GetCategoriaId(id);// localiza o produto no banco de dados
        if (categoria is null)
        {
            return NotFound();
        }

        _unitOfWork.CategoriaRepository.Delete(id);
        _unitOfWork.Commit();
        return Ok(categoria);
    }
}
