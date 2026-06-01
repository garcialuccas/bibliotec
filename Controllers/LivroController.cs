using bibliotec.Interfaces;
using bibliotec.Models;
using Microsoft.AspNetCore.Mvc;

namespace bibliotec.Controllers
{
    public class LivroController : Controller
    {
        private readonly ILivroService _service;

        public LivroController(ILivroService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            string? adminSessao = HttpContext.Session.GetString("Admin");

            if (adminSessao == null)
            {
                return RedirectToAction("Index", "Login");
            }


            ViewBag.Admin = adminSessao == "true" || adminSessao == "True";

            var livros = await _service.BuscarLivrosComCatAsync();

            return View(livros);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastro()
        {
            string? adminSessao = HttpContext.Session.GetString("Admin");
            if (adminSessao == null || (adminSessao != "true" && adminSessao != "True")) return RedirectToAction("Index", "Login");

            ViewBag.Admin = true;
            ViewBag.Categorias = await _service.ListarCategoriasAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro(Livro l, string? CategoriasSelecionadas, IFormFile arquivoImagem, string? ativo)
        {
            string? adminSessao = HttpContext.Session.GetString("Admin");
            if (adminSessao == null || (adminSessao != "true" && adminSessao != "True")) 
            {
                return RedirectToAction("Index", "Login");
            }

            await _service.CadastrarLivroAsyc(l, CategoriasSelecionadas, arquivoImagem, ativo);

            return RedirectToAction("Index", "Livro");
        }
    }
}