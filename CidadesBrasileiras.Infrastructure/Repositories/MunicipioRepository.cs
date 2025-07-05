using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Repositories;
using CidadesBrasileiras.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CidadesBrasileiras.Infrastructure.Repositories
{
    public class MunicipioRepository(AppDbContext _context) : IMunicipioRepository
    {
        public async Task<List<Municipio>> ProcurarMunicipio(int? populacaoInicial, int? populacaoFinal, string searchText)
        {
            var municipios = _context.Municipios
                .Include(x => x.Estado)
                .Where(x => EF.Functions.Like(x.Nome, $"%{searchText}%"))
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
        public async Task<List<Municipio>> ProcurarCapitais()
        {
            return _context.Municipios
                .Include(x => x.Estado)
                .Where(x => x.Capital)
                .OrderByDescending(x => x.Populacao)
                .ToList();
        }

    }
}


