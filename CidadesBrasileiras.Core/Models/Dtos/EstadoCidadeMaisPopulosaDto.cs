using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CidadesBrasileiras.Core.Models.Dtos
{
    public class EstadoCidadeMaisPopulosaDto
    {
        public string Estado { get; set; }
        public string CidadeMaisPopulosa { get; set; }
        public int Populacao { get; set; }
    }
}
