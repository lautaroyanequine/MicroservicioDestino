namespace Domain.Entities
{
    public class Ciudad
    {
        public int CiudadId { get; set; }
        public string Nombre { get; set; }

        public int ProvinciaId { get; set; }
        public Provincia Provincia { get; set; }

        public ICollection<ViajeCiudad> ViajeCiudades { get; set; }

        public InfoCiudad infoCiudad { get; set; }
    }
}
