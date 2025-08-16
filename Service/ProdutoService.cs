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
    
}