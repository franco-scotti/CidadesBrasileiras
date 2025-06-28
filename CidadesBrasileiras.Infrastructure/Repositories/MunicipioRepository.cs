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
        public async Task<Municipio?> ProcurarPorNome(string searchText)
        {
            var municipio = await _context.Municipios
                .Include(x => x.Estado)
                .FirstOrDefaultAsync(x => x.Nome == searchText);
            
            if (municipio != null) return municipio;
            
            else return null;                   
        }
    }
}
