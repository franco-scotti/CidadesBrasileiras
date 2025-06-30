using CidadesBrasileiras.Core.Models;
using CidadesBrasileiras.Core.Models.Dtos;
using CidadesBrasileiras.Infrastructure.Data;
using CidadesBrasileiras.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CidadesBrasileiras.Infrastructure.Services
{
    public class EstadoService
    {
        private readonly AppDbContext _context;
        private readonly EstadoRepository _estadoRepository;

        public EstadoService(AppDbContext context)
        {
            _context = context;
            _estadoRepository = new EstadoRepository(context);
        }

        public async Task<List<EstadoCidadeMaisPopulosaDto>> ProcucarCapitalNaoPopulosa()
        {
            return await _estadoRepository.ProcucarCapitalNaoPopulosa();
        }
    }
}
