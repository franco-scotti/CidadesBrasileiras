using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Models.Dtos;
using CidadesBrasileiras.Core.Repositories;
using CidadesBrasileiras.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace CidadesBrasileiras.Infrastructure.Repositories
{
    public class EstadoRepository(AppDbContext _context) : IEstadoRepository
    {
        public async Task<List<EstadoCidadeMaisPopulosaDto>> ProcurarCapitalNaoPopulosa()
        {
            try
            {
                var resultado = await _context.Estados
                    .Select(estado => new
                    {
                        EstadoNome = estado.Nome,
                        CidadeMaisPopulosa = estado.Municipios
                            .Where(m => !m.Capital)
                            .OrderByDescending(m => m.Populacao)
                            .FirstOrDefault(),
                    })
                    .Where(x => x.CidadeMaisPopulosa != null)
                    .Select(x => new EstadoCidadeMaisPopulosaDto
                    {
                        Estado = x.EstadoNome,
                        CidadeMaisPopulosa = x.CidadeMaisPopulosa.Nome,
                        Populacao = x.CidadeMaisPopulosa.Populacao,
                    })
                    .ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }

        }

        public async Task<List<EstadoPopulacaoTotalDto>> ProcurarEstado(int? id)
        {
            try
            {
                var query = _context.Estados.AsQueryable();

                if (id.HasValue)
                {
                    query = query.Where(e => e.Id == id.Value);
                }

                var resultado = await query
                    .Select(e => new EstadoPopulacaoTotalDto
                    {
                        Estado = e.Nome,
                        idEstado = e.Id,
                        PopulacaoTotal = e.Municipios.Sum(m => m.Populacao)
                    })
                    .ToListAsync();

                return resultado;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}