using EstoqueAgil.Contexts;
using EstoqueAgil.DTO;
using EstoqueAgil.Models;
using EstoqueAgil.Models.Enums;

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

    public List<Produto> listrarTodos(int? pagina)
    {
        var query = _contexto.produtos.AsQueryable();
        int intensPorPagina = 10;
        if (pagina != null)

            query = query.Skip(((int)pagina - 1) * intensPorPagina).Take(intensPorPagina);
        return query.ToList();
    }
    public List<Produto> listarProdutoCategoria(Categoria categoria)
    {
        List<Produto> produtos = _contexto.produtos.Where(p => p.Categoria == categoria).ToList();
        return produtos;
    }
    public Produto? atualizarPorId(string Id, ProdutoCriarDTO dto)
    {
        Produto produto = _contexto.produtos.Where(p => p.Id == Id).FirstOrDefault();
        if (produto == null)
        {
            return null;
        }
        produto.Nome = dto.nome;
        produto.Categoria = dto.Categoria;
        produto.EstoqueAtual = dto.EstoqueAtual;
        produto.Descricao = dto.Descricao;
        produto.Preco = dto.Preco;

        _contexto.SaveChanges();

        return produto;
    }
    public Produto? buscarPorId(string Id)
    {
        Produto produto = _contexto.produtos.Where(p => p.Id == Id).FirstOrDefault();
        return produto;
    }
}