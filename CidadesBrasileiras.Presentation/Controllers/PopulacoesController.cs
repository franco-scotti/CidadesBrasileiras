using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CidadesBrasileiras.Presentation.Controllers
{
    public class PopulacoesController : Controller
    {

        private readonly IMunicipioService _municipioService;

        public PopulacoesController(AppDbContext context, IMunicipioService municipioService)
        {
            _municipioService = municipioService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ProcurarPorPopulacao(int? populacaoInicial, int? populacaoFinal)
        {
            var resultado = await _municipioService.ProcurarPorPopulacao(populacaoInicial, populacaoFinal);

            if (resultado == null)
            {
                ViewBag.Mensagem = "Não foram encontrados resultados.";
            }

            return View("Index", resultado);
        }
    }
}
