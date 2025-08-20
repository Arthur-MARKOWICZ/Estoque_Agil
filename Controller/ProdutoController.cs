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
    public IActionResult cadastro([FromBody] ProdutoCadastroDTO dTO)
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
    public IActionResult obterProdutoPorId(int id)
    {
        Produto produto = _service.ObterProdutoPorId(id);
        return Ok(produto);
    }
    [HttpPatch("atualizar/{id}")]
    [Authorize]
    public IActionResult atualizarProduto([FromBody] ProdutoCadastroDTO dTO, int id)
    {
        Produto produto = _service.AlterarDadosProduto(dTO, id);
        return Ok(produto);
    }
    [HttpDelete("deletar-produto/{id}")]
    [Authorize]
    public IActionResult deletar(int id)
    {
        _service.deletarProduto(id);
        return NoContent();
    }
    [HttpGet("pegarTodos")]
    [Authorize]
    public IActionResult pegarTodos()
    {
        var produto = _service.pegarTodosProdutos(0);
        return Ok(produto);

    }
}