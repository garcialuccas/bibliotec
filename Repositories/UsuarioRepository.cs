using bibliotec.Contexts;
using bibliotec.Interfaces;
using bibliotec.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotec.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly BbDbContext _context;

        public UsuarioRepository(BbDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> BuscarPorEmailSenha(string email, string senha)
        {
            return await _context.Usuario.FirstOrDefaultAsync(u => u.Email == email && u.Senha == senha);
        }
    }
}