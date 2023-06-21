using Application.Request.InfoCiudad;
using Application.Response.InfoCiudad;

namespace Application.Interfaces.IInfoCiudad
{
    public interface IInfoCiudadService
    {
        InfoCiudadResponse CrearInfoCiudad(InfoCiudadRequest request);

        InfoCiudadResponse EliminarInfoCiudad(int id);

        InfoCiudadResponse GetPorCiudad(int ciudadId);

        InfoCiudadResponse EditarInfoCiudad(int id, InfoCiudadRequest request);

        List<InfoCiudadResponse> GetAllInfoCiudad();

        InfoCiudadResponse GetById(int id);
    }
}
