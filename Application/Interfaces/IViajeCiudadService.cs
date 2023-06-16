using Application.Request.ViajeCiudad;
using Application.Response.ViajeCiudad;

namespace Application.Interfaces
{
    public interface IViajeCiudadService
    {
        ViajeCiudadResponse CreateViajeCiudad(ViajeCiudadRequest request);
        ViajeCiudadResponse RemoveViajeCiudad(int viajeCiudadId);
        ViajeCiudadResponse UpdateViajeCiudad(int viajeCiudadId, ViajeCiudadRequest request);
        List<ViajeCiudadResponse> GetViajeCiudadList(int? viajeId, string? localizacion);
        ViajeCiudadResponse GetViajeCiudadById(int viajeCiudadId);

    }
}
