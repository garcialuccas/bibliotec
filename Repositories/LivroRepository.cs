using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Contexts;
using bibliotec.Interfaces;
using bibliotec.Models;
using Microsoft.EntityFrameworkCore;

namespace bibliotec.Repositories
{
    public class LivroRepository : ILivroRepository
    {

        private readonly BbDbContext _context;

        public LivroRepository(BbDbContext contenxt)
        {
            _context = contenxt;
        }

        public async Task<IEnumerable<Livro>> BuscarLivrosAsync()
        {
            
            return await _context.Livro.Include(l => l.LivroCategorias).ThenInclude(lc => lc.Categoria).ToListAsync();
        }
    }
}