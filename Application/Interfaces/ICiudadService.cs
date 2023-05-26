using Application.Request.Ciudad;
using Application.Response.Ciudad;

namespace Application.Interfaces
{
    public interface ICiudadService
    {
        CiudadResponse CreateCiudad(CiudadRequest request);
        CiudadResponse RemoveCiudad(int ciudadId);
        CiudadResponse UpdateCiudad(int ciudadId, CiudadRequest request);
        List<CiudadResponse> GetCiudadList(string? orden = "ASC", string? nombre = null, string? provincia = null, string? pais = null);
        CiudadResponse GetCiudadById(int ciudadId);
    }
}
