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
    }
}