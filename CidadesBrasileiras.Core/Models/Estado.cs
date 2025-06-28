namespace CidadesBrasileiras.Core.Models
{
    public class Estado
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public ICollection<Municipio> Municipios { get; set; }
    }
}
