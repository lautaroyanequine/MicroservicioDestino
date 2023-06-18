using Application.Request.ViajeCiudad;
using Domain.Entities;

namespace Application.Interfaces.IViajeCiudad
{
    public interface IViajeCiudadCommand
    {
        ViajeCiudad InsertViajeCiudad(ViajeCiudad viajeCiudad);
        ViajeCiudad UpdateViajeCiudad(int viajeciudadId, ViajeCiudadRequest request);
        ViajeCiudad RemoveViajeCiudad(int viajeCiudad);
    }
}
