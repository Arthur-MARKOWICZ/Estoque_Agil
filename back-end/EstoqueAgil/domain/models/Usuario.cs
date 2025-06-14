using System.ComponentModel.DataAnnotations;
using EstoqueAgil.DTO;
using EstoqueAgil.Models.Enums;

namespace EstoqueAgil.Models;

public class Usuario
{
    [Key]
    public string Id { get; set; } = Guid.NewGuid().ToString();

    [Required]
    [MaxLength(100)]
    public string Nome { get; set; }

    [Required]
    [EmailAddress]
    public string Email { get; set; }

    [Required]
    [MinLength(6)]
    public string Senha { get; set; }

    [Required]
    public UsuarioRole UsuarioRole { get; set; }

    public Usuario(UsuarioCadastroDTO dTO)
    {
        this.Nome = dTO.Nome;
        this.Email = dTO.Email;
        this.Senha = dTO.Senha;
    }
    public Usuario (){}
}