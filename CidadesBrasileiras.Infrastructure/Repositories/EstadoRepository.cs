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
            try
            {
                var resultado = await _context.Estados
                    .Select(estado => new
                    {
                        EstadoNome = estado.Nome,
                        CidadeMaisPopulosa = estado.Municipios
                            .Where(m => !m.Capital)
                            .OrderByDescending(m => m.Populacao)
                            .FirstOrDefault()
                    })
                    .Where(x => x.CidadeMaisPopulosa != null)
                    .Select(x => new EstadoCidadeMaisPopulosaDto
                    {
                        Estado = x.EstadoNome,
                        CidadeMaisPopulosa = x.CidadeMaisPopulosa.Nome,
                        Populacao = x.CidadeMaisPopulosa.Populacao
                    })
                    .ToListAsync();

                return resultado;
            }
            catch (Exception ex) {                
                Console.WriteLine(ex);
                return null;
            }
        }

    }
}