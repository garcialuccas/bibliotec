using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Interfaces;
using bibliotec.Models;

namespace bibliotec.Services
{
    public class LivroService : ILivroService
    {

        private readonly ILivroRepository _repository;

        public LivroService(ILivroRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Livro>> BuscarLivrosComCatAsync()
        {
            return await _repository.BuscarLivrosAsync();
        }
    }
}