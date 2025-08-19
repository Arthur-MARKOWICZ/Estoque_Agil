using EstoqueAgil.DTOs;
using EstoqueAgil.model;
using EstoqueAgil.Execao;
using System;
using System.Linq;
using System.Text;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.Extensions.Configuration;
namespace EstoqueAgil.Service;

public class UsuarioService
{
    private readonly PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();
    private readonly IConfiguration _configuration;
    private readonly EstoqueAgilDbContext _context;
    public UsuarioService(EstoqueAgilDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;

    }
    public Usuario cadastro(UsuarioCadastroDTo dTo)
    {
        Usuario usuario = new Usuario(dTo.Email, dTo.Senha, dTo.Nome);
        string hash = passwordHasher.HashPassword(usuario, dTo.Senha);
        usuario.Senha = hash;
        _context.Usuario.Add(usuario);
        _context.SaveChanges();
        return usuario;
    }
    public Usuario ObterPorId(int Id)
    {
        Usuario usuario = _context.Usuario.Find(Id);
        if (usuario == null)
        {
            throw new UsuarioNaoEncontrado("Usuário não encontrado");
        }
        return usuario;
    }
    public string login(UsuarioLoginDto dto)
    {
        Usuario usuario = _context.Usuario.FirstOrDefault(u => u.Email == dto.Email);
        if (usuario == null)
        {
            throw new UsuarioNaoEncontrado("senha ou email incorretos");
        }
        if(!usuario.Ativo){
            throw new UsuarioNaoAtivo("usuario foi desativado");
        }
        var passwordHasher = new PasswordHasher<Usuario>();
        var resultado = passwordHasher.VerifyHashedPassword(usuario, usuario.Senha, dto.Senha);
        if (resultado != PasswordVerificationResult.Success)
        {
            throw new ValidationException("senha ou email incorretos");
        }

        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim(ClaimTypes.Name, usuario.Email) }),
            Expires = DateTime.UtcNow.AddHours(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(tokenDescriptor);
        string jwt = tokenHandler.WriteToken(token);
        return jwt;
    }
    public Usuario atualizarDadosUsuario(UsuarioAtualizarDTo dTO, int id)
    {
        Usuario usuario = _context.Usuario.Find(id) ?? throw new UsuarioNaoEncontrado("usuario nao encontrado");
        usuario.AtualizarUsuario(dTO);
        if (!string.IsNullOrEmpty(dTO.Senha))
        {
            string hash = passwordHasher.HashPassword(usuario, dTO.Senha);
            usuario.Senha = hash;
        }
        _context.SaveChanges();
        return usuario;
    }
    public Usuario deletarUsuario(int id)
    {
        Usuario usuario = _context.Usuario.Find(id) ?? throw new UsuarioNaoEncontrado("usuario nao encontrado");
        usuario.Ativo = false;
        _context.SaveChanges();
        return usuario;
    }
 }