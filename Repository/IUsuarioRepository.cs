using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAgil.model;
namespace EstoqueAgil.Repository
{
    public interface IUsuarioRepository
    {
        Task<Usuario?> pegarUsuarioPorId(int id);
        Task<Usuario> salvarUsuario(Usuario usuario);
        Task<Usuario> pegarPorEmail(string email);
        Task salvarAlteracao();
    }
}