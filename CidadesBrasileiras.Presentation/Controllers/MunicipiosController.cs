using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CidadesBrasileiras.Presentation.Controllers
{
    public class MunicipiosController : Controller
    {

        private readonly IMunicipioService _municipioService;

        public MunicipiosController(AppDbContext context, IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProcurarMunicipio(int? populacaoInicial, int? populacaoFinal, string nome)
        {
            var resultado = await _municipioService.ProcurarMunicipio(populacaoInicial, populacaoFinal, nome);

            if (resultado == null)
            {
                ViewBag.Mensagem = "Não foram encontrados resultados.";
            }

            return View("Index", resultado);
        }
    }
}
