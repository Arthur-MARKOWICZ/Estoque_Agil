using Xunit;
using Moq;
using System.Linq;
using Microsoft.Extensions.Configuration;
using EstoqueAgil.Service;
using EstoqueAgil.DTOs;
using EstoqueAgil.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EstoqueAgil.Repository;
using System.Security.Claims;
using System.Collections.Generic;
using System;

namespace EstoqueAgil.Test.Unit;

public class UsuarioServiceTest
{
    private readonly UsuarioService _service;
    private readonly EstoqueAgilDbContext _context;

    public UsuarioServiceTest()
    {

        var options = new DbContextOptionsBuilder<EstoqueAgilDbContext>()
            .UseInMemoryDatabase(databaseName: "TestDb")
            .Options;
        


        _context = new EstoqueAgilDbContext(options);
        _context.Database.EnsureDeleted();
        _context.Database.EnsureCreated();
        var repo = new UsuarioRepository(_context);
        var inMemorySettings = new Dictionary<string, string> {
        {"Jwt:Key", "chave-super-secreta-para-testes-o-tamanho"},
        {"Jwt:Issuer", "EstoqueAgilTest"},
        {"Jwt:Audience", "EstoqueAgilUsersTest"}
    };
        var config = new ConfigurationBuilder().AddInMemoryCollection(inMemorySettings).Build();
        _service = new UsuarioService(config, repo);
    }

    [Fact]
    public async Task Cadastro_DeveSalvarUsuario()
    {
        // Given
        UsuarioCadastroDTo dto = new UsuarioCadastroDTo
        {
            Nome = "Arthur",
            Email = "arthur@test.com",
            Senha = "123456"
        };
        // Act
        var usuario = _service.Cadastro(dto);
        // Assert
        Assert.NotNull(usuario);
        Assert.Equal("Arthur", usuario.Nome);

        var usuarioNoBanco = await _context.Usuario.FindAsync(usuario.Id);
        Assert.NotNull(usuarioNoBanco);
        Assert.Equal("arthur@test.com", usuarioNoBanco.Email);
    }

    [Fact]
    public async Task DeveObterUsuarioPorID()
    {
        //givem
        UsuarioCadastroDTo dto = new UsuarioCadastroDTo
        {
            Nome = "Arthur",
            Email = "arthur@test.com",
            Senha = "123456"
        };

        var usuario = _service.Cadastro(dto);
        int id = usuario.Id;
        // Act
        var usuarioNoBanco = _service.ObterPorId(id);
        // Assert
        Assert.NotNull(usuarioNoBanco);
        Assert.Equal("Arthur", usuarioNoBanco.Result.Nome);
    }
    [Fact]
    public async Task DeveFazerLogin()
    {
        // Given
        UsuarioCadastroDTo dto = new UsuarioCadastroDTo
        {
            Nome = "Arthur",
            Email = "test@test.com",
            Senha = "123456"
        };
        var usuario = _service.Cadastro(dto);
        UsuarioLoginDto loginDto = new UsuarioLoginDto
        {
            Email = "test@test.com",
            Senha = "123456"
        };
        // Act
        string token = await _service.login(loginDto);
        // extraindo o id do token
        var handler = new System.IdentityModel.Tokens.Jwt.JwtSecurityTokenHandler();
        var jwtToken = handler.ReadJwtToken(token);


        var idClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "nameid")?.Value;
        var emailClaim = jwtToken.Claims.FirstOrDefault(c => c.Type == "email")?.Value;
        // Assert
        Console.WriteLine("Id do usuario criado: " + usuario.Id);
        Console.WriteLine("Id do token: " + idClaim);
        Assert.NotNull(token);
        Assert.Equal(usuario.Id.ToString(), idClaim);
        Assert.Equal(usuario.Email, emailClaim);

        }
}