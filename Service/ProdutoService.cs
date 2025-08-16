using EstoqueAgil.model;
using EstoqueAgil.Execao;
using EstoqueAgil.DTOs;
namespace EstoqueAgil.Service;

public class ProdutoService
{
    private readonly EstoqueAgilDbContext _context;
    public ProdutoService(EstoqueAgilDbContext context)
    {
        _context = context;
    }
    public Produto ObterProdutoPorId(int Id)
    {
        Produto produto = _context.Produto.Find(Id);
        if (produto == null)
        {
            throw new ProdutoNaoEncontrado("Produto nao encontrado");
        }
        return produto;
    }
    public PageResult<Produto> pegarTodosProdutos(int page, int pageSize = 10)
    {
        var query = _context.Produto.AsQueryable();

        var totalItems = query.Count();
        var items = query.Skip((page - 1) * pageSize)
                        .Take(pageSize)
                        .ToList();

        return new PageResult<Produto>
        {
            Page = page,
            PageSize = pageSize,
            TotalItems = totalItems,
            TotalPages = (int)Math.Ceiling(totalItems / (double)pageSize),
            Items = items
        };
    }
    public Produto Cadastro(ProdutoCadastroDTO dTO)
    {
        Produto produto = new Produto(dTO.Nome);
        _context.Produto.Add(produto);
        _context.SaveChanges();
        return produto;
    }
}