using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Services;
using CidadesBrasileiras.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

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

    [HttpGet]
    public async Task<IActionResult> SearchMunicipio(string nome)
    {
        if (string.IsNullOrWhiteSpace(nome))
        {
            ViewBag.Mensagem = "Digite um nome para busca.";
            return View("Index", new List<Municipio>());
        }

        var resultado = await _municipioService.ProcurarPorNome(nome);

        if (resultado == null || !resultado.Any())
        {
            ViewBag.Mensagem = $"Nenhum município encontrado para \"{nome}\".";
            resultado = new List<Municipio>();
        }

        return View("Index", resultado);
    }

}
