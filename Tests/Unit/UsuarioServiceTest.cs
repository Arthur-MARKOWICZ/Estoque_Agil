using Xunit;
using Moq;
using Microsoft.Extensions.Configuration;
using EstoqueAgil.Service;
using EstoqueAgil.DTOs;
using EstoqueAgil.model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using EstoqueAgil.Repository;
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
        var repo = new UsuarioRepository(_context);
        var config = new ConfigurationBuilder().Build();
        _service = new UsuarioService(config,repo);
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
        var usuario =  _service.Cadastro(dto);
        // Assert
          Assert.NotNull(usuario);
        Assert.Equal("Arthur", usuario.Nome);

        var usuarioNoBanco = await _context.Usuario.FindAsync(usuario.Id);
        Assert.NotNull(usuarioNoBanco);
        Assert.Equal("arthur@test.com", usuarioNoBanco.Email);
    }
}