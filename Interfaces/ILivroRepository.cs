using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Models;

namespace bibliotec.Interfaces
{
    public interface ILivroRepository
    {
        Task<IEnumerable<Livro>> BuscarLivrosAsync();

        Task<IEnumerable<Categoria>> ListarCategoriasAsync();

        Task CadastrarLivro(Livro l);

        Task CadastrarCatLivroAsync(LivroCategoria lc);

        Task ExcluirLivro(Livro l);

        Task ExcluirCatLivro(int livroid);

        Task<Livro?> BuscaLivroId(int livroid);
    }
}