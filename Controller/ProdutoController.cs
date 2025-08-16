using EstoqueAgil.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using EstoqueAgil.model;
using EstoqueAgil.DTOs;
namespace EstoqueAgil.Controller;
[ApiController]
[Route("api/Produto")]
public class ProdutoController : ControllerBase
{
    private readonly ProdutoService _service;
    public ProdutoController(ProdutoService service)
    {
        _service = service;
    }
    [HttpPost("cadastro")]
    [Authorize]
    public IActionResult cadastro([FromBody]ProdutoCadastroDTO dTO)
    {
        Produto produto = _service.Cadastro(dTO);
        return CreatedAtAction(
            nameof(obterProdutoPorId),
            new { id = produto.Id },
            produto
        );
    }
    [HttpGet("{id}")]
    [Authorize]
    public IActionResult obterProdutoPorId(int id) {
        Produto produto = _service.ObterProdutoPorId(id);
        return Ok(produto);
    }
}