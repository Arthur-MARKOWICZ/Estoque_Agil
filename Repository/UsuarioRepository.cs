using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstoqueAgil.model;
namespace EstoqueAgil.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly EstoqueAgilDbContext _context;
        public UsuarioRepository(EstoqueAgilDbContext context)
        {
            _context = context;
        }
        public async Usuario pegarUsuarioPorId(int id)
        {
            return await _context.USuario.FindAsync(id);
        }
        public async Usuario SalvarUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
        }

    }
}