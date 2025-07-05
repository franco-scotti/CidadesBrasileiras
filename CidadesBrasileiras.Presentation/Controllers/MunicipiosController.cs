using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;
using CidadesBrasileiras.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CidadesBrasileiras.Presentation.Controllers
{
    public class MunicipiosController : Controller
    {
        private readonly IMunicipioService _municipioService;

        public MunicipiosController(IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        public async Task<IActionResult> Index()
        {
            var resultado = await _municipioService.MunicipiosMaisPopulososNaoCapitais();
            return View(resultado);
        }        
    }
}
