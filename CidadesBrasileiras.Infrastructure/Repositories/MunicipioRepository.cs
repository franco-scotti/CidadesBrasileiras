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
    public class MunicipioRepository (AppDbContext _context)
    {
        public async Task<Municipio> ProcurarPorNome(string searchText)
        {
            if (searchText != null)
            {
                var municipio = await _context.Municipios
                    .Include(x => x.Estado)
                    .FirstOrDefaultAsync(x => x.Nome.ToLower() == searchText.ToLower());

                return municipio;
            }

            else return null;
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
    }
}
