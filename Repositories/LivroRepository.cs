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

        public async Task CadastrarCatLivroAsync(LivroCategoria lc)
        {
            await _context.LivroCategoria.AddAsync(lc);
            _context.SaveChanges();
        }

        public async Task CadastrarLivro(Livro l)
        {
            await _context.Livro.AddAsync(l);
            _context.SaveChanges();
        }

        public async Task ExcluirLivro(Livro l)
        {
            _context.Livro.Remove(l);
            await _context.SaveChangesAsync();
        }

        public async Task ExcluirCatLivro(int livroid)
        {
            IEnumerable<LivroCategoria> lcs = _context.LivroCategoria.Where(id => id.LivroId == livroid);
            _context.LivroCategoria.RemoveRange(lcs);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Categoria>> ListarCategoriasAsync()
        {
            return await _context.Categoria.ToListAsync();
        }

        public async Task<Livro?> BuscaLivroId(int livroid)
        {
            return await _context.Livro.FirstOrDefaultAsync(l => l.Id == livroid);
        }
    }
}