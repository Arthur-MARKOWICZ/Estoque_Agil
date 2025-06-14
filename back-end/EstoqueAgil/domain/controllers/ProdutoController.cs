using EstoqueAgil.Contexts;
using EstoqueAgil.DTO;
using EstoqueAgil.Models;
using EstoqueAgil.Models.Enums;
using EstoqueAgil.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAgil.Controllers;

[ApiController]
[Route("Produto")]
[Authorize]
public class ProdutoController : ControllerBase
{
    private readonly Context _context;
    private readonly ProdutoService service;

    public ProdutoController(Context context)
    {
        _context = context;
        service = new ProdutoService(_context);
    }

    [HttpPost("criar")]
    public IActionResult criar(ProdutoCriarDTO dTO)
    {
        Produto novoProduto = service.criar(dTO);
        ProdutoRespostaDTO produtoResposta = new ProdutoRespostaDTO(novoProduto);
        return Ok(produtoResposta);
    }
    [HttpGet("todos")]
    public IActionResult obterTodos([FromQuery] int? pagina)
    {
        List<Produto> produtos = service.listrarTodos(pagina);
        return Ok(produtos);
    }
    [HttpGet("categoria/{categoria}")]
    public IActionResult obterPorCategoria([FromRoute] Categoria categoria)
    {
        List<Produto> produtos = service.listarProdutoCategoria(categoria);
        return Ok(produtos);
    }
    [HttpPut("atualizar/{id}")]
    public IActionResult atualizarPorId([FromRoute] string id, ProdutoCriarDTO dto)
    {
        Produto produto = service.atualizarPorId(id, dto);
        if (produto == null)
        {
            return NotFound();
        }
        return Ok(produto);
    }
}
