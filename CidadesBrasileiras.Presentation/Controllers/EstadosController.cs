﻿using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;
using CidadesBrasileiras.Infrastructure.Services;
using Microsoft.AspNetCore.Mvc;

namespace CidadesBrasileiras.Presentation.Controllers
{
    public class EstadosController : Controller
    {
        private readonly IEstadoService _estadoService;

        public EstadosController (AppDbContext context)
        {
            _estadoService = new EstadoService(context);
        }

        public async Task<IActionResult> Index(int? id)
        {
            var resultado = await _estadoService.ProcurarEstado(id);
            return View(resultado);
        }

        [HttpGet]
        public async Task<IActionResult> ProcurarEstado(int? id)
        {
            var resultado = await _estadoService.ProcurarEstado(id);

            return View("Index", resultado);
        }
    }
}
