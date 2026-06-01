using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Markup;
using bibliotec.Interfaces;
using bibliotec.Models;
using Microsoft.Identity.Client;

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

        public async Task CadastrarLivroAsyc(Livro l, string? catSelecionada, IFormFile arquivoImagem, string? ativo)
        {
            l.Status = ativo == "true" || ativo == "True" ? "D" : "I";
            if (arquivoImagem != null && arquivoImagem.Length > 0)
            {
               l.Imagem = await UploadImagemAsync(arquivoImagem); 
            }
            else
            {
                l.Imagem = "";
            }

            await _repository.CadastrarLivro(l);

            if (!string.IsNullOrEmpty(catSelecionada))
            {
                var categoriaIds = catSelecionada.Split(",").Select(id => int.TryParse(id, out var convertido) ? convertido : 0).Where(id => id > 0).ToList();

                foreach(var catId in categoriaIds)
                {
                    LivroCategoria lc = new LivroCategoria
                    {
                        LivroId = l.Id,
                        CategoriaId = catId
                    };
                    await _repository.CadastrarCatLivroAsync(lc);
                }
            }
        }

        public async Task<IEnumerable<Categoria>> ListarCategoriasAsync()
        {
                return await _repository.ListarCategoriasAsync();
        }

        private async Task<string> UploadImagemAsync(IFormFile arquivoImagem)
        {
            string caminhoPasta = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "img", "capaLivros");
            
            if (!Directory.Exists(caminhoPasta)) Directory.CreateDirectory(caminhoPasta);
            
            var nomeArquivo = Guid.NewGuid().ToString() + Path.GetExtension(arquivoImagem.FileName);

            var caminhoArquivo = Path.Combine(caminhoPasta, nomeArquivo);

            using (var stream = new FileStream(caminhoArquivo, FileMode.Create))
            {
                await arquivoImagem.CopyToAsync(stream);
            }

            return $"img/capaLivros/{nomeArquivo}";
        }
    }
}