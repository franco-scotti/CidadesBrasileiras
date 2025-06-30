using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Models.Dtos;
using CidadesBrasileiras.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CidadesBrasileiras.Infrastructure.Repositories
{
    public class EstadoRepository(AppDbContext _context)
    {
        public async Task<List<EstadoCidadeMaisPopulosaDto>> ProcucarCapitalNaoPopulosa()
        {
            var resultado = new List<EstadoCidadeMaisPopulosaDto>();

            var todosEstados = await _context.Estados
                .Include(x => x.Municipios)
                .ToListAsync();

            foreach (var estado in todosEstados)
            {
                var municipiosOrdenados = estado.Municipios
                    .OrderByDescending(m => m.Populacao)
                    .ToList();

                var maisPopulosa = municipiosOrdenados.FirstOrDefault();

                if (maisPopulosa != null && !maisPopulosa.Capital)
                {
                    resultado.Add(new EstadoCidadeMaisPopulosaDto
                    {
                        Estado = estado.Nome,
                        CidadeMaisPopulosa = maisPopulosa.Nome,
                        Populacao = maisPopulosa.Populacao
                    });
                }
            }

            return resultado;
        }
    }
}