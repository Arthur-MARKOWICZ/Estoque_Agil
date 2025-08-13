using EstoqueAgil.Service;
using Microsoft.AspNetCore.Mvc;
using EstoqueAgil.model;
using EstoqueAgil.DTOs;
namespace EstoqueAgil.Controller;

[ApiController]
[Route("api/Usuario")]
public class UsuarioController : ControllerBase
{
    private readonly UsuarioService _usuarioService;
    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }
    [HttpPost("cadastro")]
    public IActionResult CriarProduto([FromBody] UsuarioCadastroDTo usuarioCadastroDTO)
    {
        Usuario usuario = _usuarioService.cadastro(usuarioCadastroDTO);
        return CreatedAtAction(
        nameof(ObterUsuarioPorId),
        new { id = usuario.Id },   
        usuario                    
    );
    }
    [HttpGet("{id}")]
    public IActionResult ObterUsuarioPorId(int id)
    {
        var usuario = _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }
      [HttpPost("login")]
    public IActionResult Login([FromBody] UsuarioLoginDto dto)
    {
        
        string token = _usuarioService.login(dto);
        return Ok(new { token });
    }

}