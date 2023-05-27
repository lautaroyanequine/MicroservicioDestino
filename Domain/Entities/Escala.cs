namespace Domain.Entities
{
    public class Escala
    {
        public int EscalaId { get; set; }
        public string NombreParada { get; set; }
        public DateTime HoraLlegada { get; set; }
        public DateTime HoraSalida { get; set; }
        public int ViajeId { get; set; }
        public int CiudadId { get; set; }
        public Ciudad Ciudad { get; set; }
    }
}
