using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Models.Dtos;

namespace CidadesBrasileiras.Core.Services
{
    public interface IEstadoService
    {
        Task<List<EstadoCidadeMaisPopulosaDto>> ProcurarCapitalNaoPopulosa();
        Task<List<EstadoPopulacaoTotalDto>> ProcurarEstado(int? id);

    }
}
