using Domain.Entities;

namespace Application.Interfaces
{
    public interface ICiudadQuery
    {
        List<Ciudad> GetCiudadList(string? orden = "ASC", string? nombre = null, string? provincia = null, string? pais = null);
        Ciudad GetCiudad(int ciudadId);
        Ciudad GetCiudad(string nombreCiudad);
    }
}
