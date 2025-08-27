using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

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
        public async Task<Usuario?> pegarUsuarioPorId(int id)
        {
            return await _context.Usuario.FindAsync(id);
        }
        public async Task<Usuario> salvarUsuario(Usuario usuario)
        {
            _context.Usuario.Add(usuario);
            _context.SaveChanges();
            return usuario;
        }

        public async Task<Usuario> pegarPorEmail(string email)
        {
            Usuario usuario = await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email);
            return usuario;
        }
        public async Task salvarAlteracao()
        {
            await _context.SaveChangesAsync();
        }


    }
}