using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;
using CidadesBrasileiras.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CidadesBrasileiras.Presentation.Controllers
{
    public class MunicipiosController : Controller
    {
        private readonly MunicipioService _municipiosService;

        public MunicipiosController(AppDbContext context)
        {
            _municipiosService = new MunicipioService(context);
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await _municipiosService.MunicipiosMaisPopulososNaoCapitais();
            return View(resultado);
        }        
    }
}
