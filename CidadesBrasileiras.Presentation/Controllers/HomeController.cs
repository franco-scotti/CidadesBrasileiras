using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Services;
using CidadesBrasileiras.Presentation.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CidadesBrasileiras.Presentation.Controllers;

public class HomeController : Controller
{
    private readonly IMunicipioService _municipioService;

    public HomeController(AppDbContext context, IMunicipioService municipioService)
    {
        _municipioService = municipioService;
    }

    public async Task<IActionResult> Index()
    {
        var resultado = await _municipioService.MunicipiosMaisPopulososNaoCapitais();
        return View(resultado);
    }

}
