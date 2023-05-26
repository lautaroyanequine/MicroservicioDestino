namespace Domain.Entities
{
    public class Pais
    {
        public int PaisId { get; set; }
        public string Nombre { get; set; }
        public string Codigo { get; set; }


        public ICollection<Provincia> Provincias { get; set; }
    }
}
