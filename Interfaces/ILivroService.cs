using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Models;

namespace bibliotec.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> BuscarLivrosComCatAsync();

        Task<IEnumerable<Categoria>> ListarCategoriasAsync();

        Task CadastrarLivroAsyc(Livro l, string? catSelecionada, IFormFile arquivoImagem, string? ativo);

        Task<bool> RemoverLivroAsync(int id);

    }
}