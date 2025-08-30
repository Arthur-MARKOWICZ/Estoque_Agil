using EstoqueAgil.Service;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
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
    [AllowAnonymous]
    public IActionResult CriarUsuario([FromBody] UsuarioCadastroDTo usuarioCadastroDTO)
    {
        Usuario usuario = _usuarioService.Cadastro(usuarioCadastroDTO);
        return CreatedAtAction(
        nameof(ObterUsuarioPorId),
        new { id = usuario.Id },
        usuario
    );
    }
    [HttpGet("{id}")]
    [Authorize]
    public  async Task<IActionResult> ObterUsuarioPorId(int id)
    {
        var usuario = await _usuarioService.ObterPorId(id);
        if (usuario == null)
            return NotFound();

        return Ok(usuario);
    }
    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] UsuarioLoginDto dto)
    {
        string token = await _usuarioService.login(dto);
        return Ok(new UsuarioLoginRespostaDTO(token));
    }
    [HttpPatch("atualizar-dados/{id}")]
    [Authorize]
    public async Task<IActionResult> AtualizarDadosUsuario(int id, [FromBody] UsuarioAtualizarDTo dTo)
    {
        Usuario usuario = await _usuarioService.atualizarDadosUsuario(dTo, id);
        return Ok(usuario);
    }
    [HttpDelete("deletar-usuario/{id}")]
    [Authorize]
    public async Task<IActionResult> deletearUsuario(int id)
    {
        Usuario usuario = await _usuarioService.deletarUsuario(id);
        return Ok(usuario);
    }

}