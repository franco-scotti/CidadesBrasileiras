using CidadesBrasileiras.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CidadesBrasileiras.Core.Services
{
    public interface IMunicipioService
    {
        Task<List<Municipio>> MunicipiosMaisPopulososNaoCapitais();
        Task<List<Municipio>> ProcurarCapitais();
        Task<List<Municipio>> ProcurarPorNome(string searchText);
        Task<List<Municipio>> ProcurarPorPopulacao(int? populacaoInicial, int? populacaoFinal);
    }
}
