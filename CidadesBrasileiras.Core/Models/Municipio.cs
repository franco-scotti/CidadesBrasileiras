namespace CidadesBrasileiras.Core.Models
{
    public class Municipio
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool Capital { get; set; }
        public int Populacao { get; set; }

        public int IdEstado { get; set; }
        public Estado Estado { get; set; }
    }
}
