using EstoqueAgil.Models;
using EstoqueAgil.Models.Enums;

namespace EstoqueAgil.DTO;

public class ProdutoRespostaDTO
{
    public string nome;
    public string Descricao { get; set; }

    public decimal Preco { get; set; }

    public int EstoqueAtual { get; set; }
    public Categoria Categoria { get; set; }

    public ProdutoRespostaDTO() { }
    public ProdutoRespostaDTO(Produto produto)
    {
        this.nome = produto.Nome;
        this.Descricao = produto.Descricao;
        this.Preco = produto.Preco;
        this.EstoqueAtual = produto.EstoqueAtual;
        this.Categoria = produto.Categoria;
     }
}