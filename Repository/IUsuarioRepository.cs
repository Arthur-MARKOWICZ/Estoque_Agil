using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAgil.model;
namespace EstoqueAgil.Repository
{
    public interface IUsuarioRepository
    {
        Usuario? pegarUsuarioPorId(int id);
        Usuario salvarUsuario(Usuario usuario);

    }
}