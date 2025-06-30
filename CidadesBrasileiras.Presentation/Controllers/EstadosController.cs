using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;
using CidadesBrasileiras.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CidadesBrasileiras.Presentation.Controllers
{
    public class EstadosController : Controller
    {
        private readonly EstadoService _estadoService;

        public EstadosController (AppDbContext context)
        {
            _estadoService = new EstadoService(context);
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await _estadoService.ProcucarCapitalNaoPopulosa();
            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ProcucarCapitalNaoPopulosa()
        {
            var resultado = await _estadoService.ProcucarCapitalNaoPopulosa();

            return View("Index", resultado);
        }
    }
}
