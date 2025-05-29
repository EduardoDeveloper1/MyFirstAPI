using API_net9.DTOs;
using API_net9.DTOs.Mappings;
using API_net9.Models;
using API_net9.Repositories;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult<IEnumerable<CategoriaDTO>> GetAll()
    {
        var categorias = _unitOfWork.CategoriaRepository.GetAllCategorias();

       if(categorias is null)
        {
            return NotFound();
        }

        var categoriaDTO = categorias.ToCategoriaDTOList();

        return Ok(categoriaDTO);
    }

    [HttpGet("{id:int:min(1)}", Name = "Obter categoria")]
    public ActionResult<CategoriaDTO> GetForId(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.GetCategoriaId(id);

        if(categoria is null)
        {
            return NotFound();
        }

        var categoriaDto = categoria.ToCategoriaDTO();

        return Ok(categoriaDto); // Aqui retornamos o objeto corretamente

    }

    [HttpPost]
    //cria ou altera uma categoria existente
    public ActionResult<CategoriaDTO> Post(CategoriaDTO categoriaDTO)
    {
        if (categoriaDTO is null)
        {
            return BadRequest();
        }

        var categoria = categoriaDTO.ToCategoria();

        _unitOfWork.CategoriaRepository.Create(categoria);// inclui no contexto
        _unitOfWork.Commit();

        var Novacategoria = categoria.ToCategoriaDTO();

        return new CreatedAtRouteResult("Obter categoria", new { id = categoriaDTO.CategoriaId }, categoriaDTO);
    }

    [HttpPut("{id:int}")]
    // método para alterar um produto existente
    public ActionResult<CategoriaDTO> Put(int id, CategoriaDTO categoriaDTO)
    {
        if (id != categoriaDTO.CategoriaId)
        {
            return BadRequest();
        }

        var categoria = categoriaDTO.ToCategoria();

        _unitOfWork.CategoriaRepository.Update(categoria);
        _unitOfWork.Commit();

        var Novacategoria = categoria.ToCategoriaDTO();

        return Ok(Novacategoria);
    }

    [HttpDelete("{id:int}")]
    public ActionResult<CategoriaDTO> Delete(int id)
    {
        var categoria = _unitOfWork.CategoriaRepository.GetCategoriaId(id);// localiza o produto no banco de dados
        if (categoria is null)
        {
            return NotFound();
        }

        _unitOfWork.CategoriaRepository.Delete(id);
        _unitOfWork.Commit();

        var Novacategoria = categoria.ToCategoriaDTO();

        return Ok(Novacategoria);
    }
}
