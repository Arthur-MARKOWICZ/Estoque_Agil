using EstoqueAgil.Contexts;
using EstoqueAgil.DTO;
using EstoqueAgil.Models;
using EstoqueAgil.Services;
using Microsoft.AspNetCore.Mvc;

namespace EstoqueAgil.Controllers;

[ApiController]
[Route("Account")]
public class UsuarioController : ControllerBase
{
    private readonly Context _context;
    private UsuarioService service;
    private readonly IConfiguration _config;
    public UsuarioController(Context context, IConfiguration config)
    {
        _context = context;
        service = new UsuarioService(_context,config);
    }
    [HttpPost("Login")]
    public IActionResult Login(UsuarioLoginDTO Dto)
    {
        Usuario usuario = service.Login(Dto);
        if (usuario == null)
        {
            return BadRequest("Email ou senha incorretos");
        }
        string token = service.GerarToken(usuario.Email);
        UsuarioLoginRespostaDTO login = new UsuarioLoginRespostaDTO();
        login.token = token;
        login.Nome = usuario.Nome;
        return Ok(login);
    }
    [HttpPost("cadastro")]
    public IActionResult cadastro(UsuarioCadastroDTO dTO)
    {
        Usuario usuario =  service.Cadastro(dTO);
        return Ok(usuario);
    }
}