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
using EstoqueAgil.Repository;
namespace EstoqueAgil.Service;

public class UsuarioService
{
    private readonly PasswordHasher<Usuario> passwordHasher = new PasswordHasher<Usuario>();
    private readonly IConfiguration _configuration;

    private readonly IUsuarioRepository _repository;
    public UsuarioService( IConfiguration configuration, IUsuarioRepository repository)
    {

        _configuration = configuration;
        _repository = repository;

    }
    public Usuario cadastro(UsuarioCadastroDTo dTo)
    {
        Usuario usuario = new Usuario(dTo.Email, dTo.Senha, dTo.Nome);
        string hash = passwordHasher.HashPassword(usuario, dTo.Senha);
        usuario.Senha = hash;
        _repository.salvarUsuario(usuario);
        return usuario;
    }
    public async Task<Usuario> ObterPorId(int Id)
    {
        Usuario usuario = await _repository.pegarUsuarioPorId(Id);
        if (usuario == null)
        {
            throw new UsuarioNaoEncontrado("Usuário não encontrado");
        }
        return usuario;
    }
    public async Task<string> login(UsuarioLoginDto dto)
    {
        Usuario usuario = await _repository.pegarPorEmail(dto.Email);
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
    public async Task<Usuario> atualizarDadosUsuario(UsuarioAtualizarDTo dTO, int id)
    {
        Usuario usuario = await _repository.pegarUsuarioPorId(id) ?? throw new UsuarioNaoEncontrado("usuario nao encontrado");
        usuario.AtualizarUsuario(dTO);
        if (!string.IsNullOrEmpty(dTO.Senha))
        {
            string hash = passwordHasher.HashPassword(usuario, dTO.Senha);
            usuario.Senha = hash;
        }
        _repository.salvarAlteracao();
        return usuario;
    }
    public async Task<Usuario> deletarUsuario(int id)
    {
        Usuario usuario = await _repository.pegarUsuarioPorId(id) ?? throw new UsuarioNaoEncontrado("usuario nao encontrado");
        usuario.Ativo = false;
        _repository.salvarAlteracao();
        return usuario;
    }
 }