namespace Domain.Entities
{
    public class ViajeCiudad
    {
        public int ViajeCiudadId { get; set; }

        public Guid ViajeId { get; set; }

        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
