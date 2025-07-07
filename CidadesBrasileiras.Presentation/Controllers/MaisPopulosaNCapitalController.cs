using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;
using CidadesBrasileiras.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CidadesBrasileiras.Presentation.Controllers
{
    public class MaisPopulosaNCapitalController : Controller
    {
        private readonly IEstadoService _estadoService;

        public MaisPopulosaNCapitalController(AppDbContext context)
        {
            _estadoService = new EstadoService(context);
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await _estadoService.ProcurarCapitalNaoPopulosa();
            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ProcurarCapitalNaoPopulosa()
        {
            var resultado = await _estadoService.ProcurarCapitalNaoPopulosa();

            return View("Index", resultado);
        }
    }
}
