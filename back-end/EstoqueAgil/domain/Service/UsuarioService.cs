using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EstoqueAgil.Contexts;
using EstoqueAgil.DTO;
using EstoqueAgil.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace EstoqueAgil.Services;

public class UsuarioService
{
    private readonly Context _contexto;
    private readonly PasswordHasher<Usuario> _passwordHasher = new();
    private readonly IConfiguration _config;


    public UsuarioService(Context db, IConfiguration config)
    {
        _contexto = db;
        _config = config;
    }
    public Usuario Login(UsuarioLoginDTO Dto)
    {
        Usuario usuario = _contexto.usuarios.Where(u => u.Email == Dto.Email).FirstOrDefault();
        var resultado = _passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, Dto.senha);
        return resultado == PasswordVerificationResult.Success ? usuario : null;
    }
    public Usuario Cadastro(UsuarioCadastroDTO dTO)
    {
        Usuario usuario = new Usuario(dTO);
        usuario.Senha = _passwordHasher.HashPassword(usuario, dTO.Senha);
        _contexto.usuarios.Add(usuario);
        _contexto.SaveChanges();
        return usuario;
    }
      public string GerarToken(string username)
    {
        var claims = new[]
        {
            new Claim(JwtRegisteredClaimNames.Sub, username),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        var token = new JwtSecurityToken(
            issuer: _config["Jwt:Issuer"],
            audience: _config["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddMinutes(30),
            signingCredentials: creds);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
