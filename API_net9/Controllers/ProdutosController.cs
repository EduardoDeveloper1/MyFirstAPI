﻿using API_net9.Models;
using API_net9.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace API_net9.Controllers;

[Route("[controller]")] // Dessa forma a rota é definida apenas com o nome do controlador
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IUnitOfWork _unitOfWork;

    public ProdutosController(IUnitOfWork unitOfWork) // fazendo a injeção de dependencia para acessar os dados do banco
    {
        _unitOfWork = unitOfWork;
    }

    [HttpGet]
    public ActionResult<IEnumerable<Produto>> GetAll()
    {
        var produtos = _unitOfWork.ProdutoRepository.GetAllProdutos();
        return Ok(produtos);
    }

    [HttpGet("{id:int}", Name = "Obter produto")] // especifica que o valor tem que ser do tipo int
    public ActionResult<Produto> GetForId(int id)
    {
        var produto = _unitOfWork.ProdutoRepository.GetProdutoId(id);
        if(produto is null)
        {
            return NotFound();
        }
        return produto;
    }

    [HttpPost]
    //Este método permite que um cliente envie dados de um novo produto em uma requisição POST. Caso os dados sejam válidos,
    //o produto é salvo no banco de dados,
    //e uma resposta é enviada indicando sucesso, com a localização do recurso recém-criado.
    public ActionResult Post(Produto produto)
    {
        if(produto is null)
        {
            return BadRequest();
        }

        _unitOfWork.ProdutoRepository.Create(produto);
        _unitOfWork.Commit();

        return new CreatedAtRouteResult("Obter produto", new { id = produto.ProdutoId }, produto);
    }

    [HttpPut("{id:int}")]
    // método para alterar um produto existente
    public ActionResult Put(int id, Produto produto)
    {
        if(id != produto.ProdutoId)
        {
            return BadRequest();
        }

        _unitOfWork.ProdutoRepository.Update(produto);
        _unitOfWork.Commit();
        return Ok(produto);
    }

    [HttpDelete("id:int")]
    public ActionResult Delete(int id)
    {
        var produto = _unitOfWork.ProdutoRepository.Delete(id);// localiza o produto no banco de dados
        if(produto is null)
        {
            return NotFound();
        }
        _unitOfWork.ProdutoRepository.Delete(id);
        _unitOfWork.Commit();
        return Ok(produto);
    }
}
