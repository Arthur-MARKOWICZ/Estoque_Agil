using EstoqueAgil.Models.Enums;

namespace EstoqueAgil.DTO;

public class ProdutoCriarDTO
{
    public string nome { get; set; }
     public string Descricao { get; set; }

    public decimal Preco { get; set; }

    public int EstoqueAtual { get; set; }
    public Categoria Categoria { get; set; }
}