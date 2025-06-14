using System.ComponentModel.DataAnnotations;
using EstoqueAgil.DTO;
using EstoqueAgil.Models.Enums;

namespace EstoqueAgil.Models;

public class Produto
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();
    [Required]
    [MaxLength(100)]

    public string Nome { get; set; }
    [Required]
    [MaxLength(255)]
    public string Descricao { get; set; }
    [Required]
    public decimal Preco { get; set; }
    [Required]
    public int EstoqueAtual { get; set; }
    public Categoria Categoria { get; set; }
    public Produto(){}
    public Produto(ProdutoCriarDTO dto)
    {
        this.Nome = dto.nome;
        this.Descricao = dto.Descricao;
        this.Preco = dto.Preco;
        this.EstoqueAtual = dto.EstoqueAtual;
        this.Categoria = dto.Categoria;
    }


}