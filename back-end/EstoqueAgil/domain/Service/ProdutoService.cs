using EstoqueAgil.Contexts;
using EstoqueAgil.DTO;
using EstoqueAgil.Models;

namespace EstoqueAgil.Services;

public class ProdutoService
{
    private readonly Context _contexto;
    public ProdutoService(Context context)
    {
        _contexto = context;
    }

    public Produto criar(ProdutoCriarDTO DTO)
    {
        Produto novoProduto = new Produto(DTO);
        _contexto.produtos.Add(novoProduto);
        _contexto.SaveChanges();
        return novoProduto;
    }
}