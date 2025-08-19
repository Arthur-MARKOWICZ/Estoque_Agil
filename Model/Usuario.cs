using EstoqueAgil.DTOs;
namespace EstoqueAgil.model;

public class Usuario
{
    public Usuario(string Email, string Nome, string Senha)
    {
        this.Email = Email;
        this.Senha = Senha;
        this.Nome = Nome;
    }
    public int Id { get; set; }
    public string Email { get; set; }
    public string Senha { get; set; }
    public string Nome { get; set; }

    public bool Ativo { get; set; } = true;
    public void AtualizarUsuario(UsuarioAtualizarDTo dTO)
    {
        Email = dTO.Email;
        Nome = dTO.Nome;
    }
}