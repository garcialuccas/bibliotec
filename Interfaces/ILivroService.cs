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
    }
}