namespace EstoqueAgil.model;

public class Produto
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;

    public int UsuarioId{ get; set; }
     public Usuario Usuario { get; set; }  
    public Produto(string Nome)
    {
        this.Nome = Nome;
    }
}