using Domain.Entities;

namespace Application.Interfaces.IProvincia
{
    public interface IProvinciaQuery
    {
        List<Provincia> GetProvinciaList(string? orden = "ASC", string? nombre = null, string? pais = null);
        Provincia GetProvincia(int provinciaId);
        Provincia GetProvincia(string nombreProvincia);
    }
}
