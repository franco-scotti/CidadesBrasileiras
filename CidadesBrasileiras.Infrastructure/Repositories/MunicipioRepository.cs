using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CidadesBrasileiras.Infrastructure.Repositories
{
    public class MunicipioRepository(AppDbContext _context)
    {
        public async Task<List<Municipio>> ProcurarPorNome(string searchText)
        {
            try
            {
                searchText = searchText ?? string.Empty;

                var searchLower = searchText.ToLower();

                var municipios = await _context.Municipios
                    .Include(x => x.Estado)
                    .Where(x => EF.Functions.Like(x.Nome.ToLower(), $"%{searchLower}%"))
                    .ToListAsync();

                return municipios;
            }
            catch
            {
                return new List<Municipio>();
            }
        }

        public async Task<List<Municipio>> ProcurarPorPopulacao(int? populacaoInicial, int? populacaoFinal)
        {
            var municipios = _context.Municipios
                .Include(x => x.Estado)
                .AsQueryable();

            if (populacaoInicial.HasValue)
            {
                municipios = municipios.Where(x => x.Populacao > populacaoInicial.Value);
            }

            if (populacaoFinal.HasValue)
            {
                municipios = municipios.Where(x => x.Populacao < populacaoFinal.Value);
            }

            return await municipios.ToListAsync();
        }

        public async Task<List<Municipio>> MunicipiosMaisPopulososNaoCapitais()
        {
            return _context.Municipios
                .Include(x => x.Estado)
                .Where(x => !x.Capital)
                .OrderByDescending(x => x.Populacao)
                .Take(10)
                .ToList();
        }
    }
}


