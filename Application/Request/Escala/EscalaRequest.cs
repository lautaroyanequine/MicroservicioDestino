namespace Application.Request.Escala
{
    public class EscalaRequest
    {
        public string NombreParada { get; set; }
        public string HoraLlegada { get; set; }
        public string HoraSalida { get; set; }
        public Guid ViajeId { get; set; }
        public int CiudadId { get; set; }
    }
}
