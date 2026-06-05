using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using bibliotec.Interfaces;
using bibliotec.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace bibliotec.Controllers
{
    public class ReservaController : Controller
    {
        private readonly IReservaService _service;

        public ReservaController(IReservaService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            string? adminSessao = HttpContext.Session.GetString("Admin");

            int.TryParse(HttpContext.Session.GetString("UsuarioId"), out int usuarioId);

            if (adminSessao == null || (adminSessao != "true" && adminSessao != "True")) return RedirectToAction("Index", "Login");
            
            ViewBag.Admin = adminSessao == "True" || adminSessao == "true";

            IEnumerable<Reserva> reservas;

            if (ViewBag.Admin) reservas = await _service.BuscarReservasAsync();

            else reservas = await _service.BuscarReservasPorUsuarioAsync(usuarioId);

            return View(reservas);
        }
    }
}