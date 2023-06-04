using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeCiudadQuery
    {
        List<ViajeCiudad> GetViajeCiudadList(int? viajeId, string? localizacion);
        ViajeCiudad GetViajeCiudad(int viajeCiudadId);
    }
}
