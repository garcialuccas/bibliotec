using bibliotec.Interfaces;
using bibliotec.Models;
using Microsoft.AspNetCore.Mvc;

namespace bibliotec.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public LoginController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        // public async Task<IActionResult> Logar(string email, string senha)
        // {
        //     Usuario? usuario = await _usuarioService.AutenticarUsuario(email, senha);
            
        //     if (usuario != null)
        //     {
        //         return 
        //     }

        // }
    }
}