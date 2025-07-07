using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Models.Dtos;
using CidadesBrasileiras.Core.Repositories;
using CidadesBrasileiras.Core.Services;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;

namespace CidadesBrasileiras.Infrastructure.Services
{
    public class EstadoService : IEstadoService
    {
        private readonly AppDbContext _context;
        private readonly IEstadoRepository _estadoRepository;

        public EstadoService(AppDbContext context)
        {
            _context = context;
            _estadoRepository = new EstadoRepository(context);
        }

        public async Task<List<EstadoCidadeMaisPopulosaDto>> ProcurarCapitalNaoPopulosa()
        {
            return await _estadoRepository.ProcurarCapitalNaoPopulosa();
        }

        Task<List<EstadoPopulacaoTotalDto>> IEstadoService.ProcurarEstado(int? id)
        {
            return _estadoRepository.ProcurarEstado(id);
        }
    }
}
