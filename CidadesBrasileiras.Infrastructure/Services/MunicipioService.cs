using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;

namespace CidadesBrasileiras.Infrastructure.Services
{
    public class MunicipioService
    {
        private readonly AppDbContext _context;
        private readonly MunicipioRepository _municipioRepository;

        public MunicipioService(AppDbContext context)
        {
            _context = context;
            _municipioRepository = new MunicipioRepository(context);
        }

        public async Task<Municipio> ProcurarPorNome(string searchText)
        {
            return await _municipioRepository.ProcurarPorNome(searchText);
        }

        public async Task<List<Municipio>> ProcurarPorPopulacao(int? populacaoInicial, int? populacaoFinal)
        {
            return await _municipioRepository.ProcurarPorPopulacao(populacaoInicial, populacaoFinal);
        }
    }
}
