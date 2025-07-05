using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Repositories;
using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;

namespace CidadesBrasileiras.Infrastructure.Services
{
    public class MunicipioService : IMunicipioService
    {
        private readonly IMunicipioRepository _municipioRepository;

        public MunicipioService(AppDbContext context, IMunicipioRepository municipioRepository)
        {
            _municipioRepository = municipioRepository;
        }

        public async Task<List<Municipio>> ProcurarMunicipio(int? populacaoInicial, int? populacaoFinal, string searchText)
        {
            return await _municipioRepository.ProcurarMunicipio(populacaoInicial, populacaoFinal, searchText);
        }

        public async Task<List<Municipio>> MunicipiosMaisPopulososNaoCapitais()
        {
            return await _municipioRepository.MunicipiosMaisPopulososNaoCapitais();
        }

        public async Task<List<Municipio>> ProcurarCapitais()
        {
            return await _municipioRepository.ProcurarCapitais();
        }

    }
}
