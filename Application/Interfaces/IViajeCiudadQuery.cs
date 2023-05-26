using Domain.Entities;

namespace Application.Interfaces
{
    public interface IViajeCiudadQuery
    {
        List<ViajeCiudad> GetViajeCiudadList();
        ViajeCiudad GetViajeCiudad(int viajeCiudadId);
    }
}
