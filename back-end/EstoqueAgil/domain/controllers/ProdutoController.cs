using EstoqueAgil.Contexts;
using EstoqueAgil.DTO;
using EstoqueAgil.Models;
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
}
