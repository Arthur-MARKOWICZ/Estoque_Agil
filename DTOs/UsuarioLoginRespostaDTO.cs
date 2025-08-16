namespace EstoqueAgil.DTOs;

public class UsuarioLoginRespostaDTO
{
    public string Token { get; set; }
    public UsuarioLoginRespostaDTO(string Token)
    {
        this.Token = Token;
    }
}