using EstoqueAgil.model;
using EstoqueAgil.Execao;
using EstoqueAgil.DTOs;
using EstoqueAgil.Repository;
using System.IdentityModel.Tokens.Jwt; 
using System.Security.Claims;          
using System.Text;                       
using Microsoft.IdentityModel.Tokens; 
namespace EstoqueAgil.Service;

public class ProdutoService
{
    private readonly IProdutoRepository _context;   
     private readonly IHttpContextAccessor _httpContextAccessor;
    public ProdutoService(IProdutoRepository context, IHttpContextAccessor httpContextAccessor)
    {
        _context = context;
        _httpContextAccessor = httpContextAccessor;

    }
    public async Task<Produto> ObterProdutoPorId(int Id)
    {
        Produto produto =  await _context.PegarPorId(Id);
        if (produto == null)
        {
            throw new ProdutoNaoEncontrado("Produto nao encontrado");
        }
        return produto;
    }

    public async Task<PageResult<Produto>> pegarTodosProdutos(int page, int pageSize = 10)
    {
        PageResult<Produto> pageResult =await _context.pegarTodosProdutos(page, pageSize);
        return pageResult;
}

    public async Task<Produto> Cadastro(ProdutoCadastroDTO dTO)
    {
          var userId = _httpContextAccessor.HttpContext?.User
            ?.FindFirstValue(ClaimTypes.NameIdentifier);

        if (string.IsNullOrEmpty(userId))
            throw new UnauthorizedAccessException("Usuário não autenticado.");

        Produto produto = new Produto(dTO.Nome)
        {
            UsuarioId = int.Parse(userId) 
        };
         await _context.SalvarProduto(produto);
        return produto;
    }
    public async Task<Produto> AlterarDadosProduto(ProdutoCadastroDTO dTO, int id)
    {
        Produto produto = await _context.PegarPorId(id);
        if (produto == null)
        {
            throw new ProdutoNaoEncontrado("Produto nao encontrado");
        }
        produto.Nome = dTO.Nome;
        await _context.SalvarAlteracao();
        return produto;
    }
    public async Task<Produto> deletarProduto(int id)
    {
        Produto produto = await _context.PegarPorId(id);
        if (produto == null)
        {
            throw new ProdutoNaoEncontrado("Produto nao encontrado");
        }
        _context.DeletarProduto(produto);
        return produto;
    }
}