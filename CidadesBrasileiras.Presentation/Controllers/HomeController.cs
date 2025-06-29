using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using CidadesBrasileiras.Presentation.Models;
using CidadesBrasileiras.Infrastructure.Services;
using CidadesBrasileiras.Infrastructure.Data;

namespace CidadesBrasileiras.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly MunicipioService _municipioService;

    public HomeController(AppDbContext context)
    {
        _municipioService = new MunicipioService(context);
    }

    public IActionResult Index()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    [HttpGet]
    public async Task<IActionResult> SearchMunicipio(string nome)
    {
        var resultado = await _municipioService.ProcurarPorNome(nome);

        if (resultado == null)
        {
            ViewBag.Mensagem = $"Município \"{nome}\" não encontrado.";
        }

        return View("Index", resultado);
    }
}
