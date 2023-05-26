using Domain.Entities;

namespace Application.Interfaces
{
    public interface IPaisQuery
    {
        List<Pais> GetPaisList(string? orden = "ASC", string? nombre = null);
        Pais GetPais(int paisId);
        Pais GetPais(string nombrePais);
    }
}
