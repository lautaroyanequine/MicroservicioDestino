using Application.Interfaces;
using Application.Request.ViajeCiudad;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class ViajeCiudadCommand : IViajeCiudadCommand
    {
        private readonly DestinosContext _context;
        public ViajeCiudadCommand(DestinosContext context) { _context = context; }

        public ViajeCiudad InsertViajeCiudad(ViajeCiudad viajeCiudad)
        {
            _context.Add(viajeCiudad);
            _context.SaveChanges();

            return viajeCiudad;
        }

        public ViajeCiudad RemoveViajeCiudad(int viajeCiudadId)
        {
            var viajeCiudad = _context.ViajeCiudades.Include(c => c.Ciudad)
                 .ThenInclude(pr => pr.Provincia)
                 .ThenInclude(pa => pa.Pais)
                      .FirstOrDefault(x => x.ViajeCiudadId == viajeCiudadId);

            if (viajeCiudad != null)
            {
                _context.Remove(viajeCiudad);
                _context.SaveChanges();
            }


            return viajeCiudad;
        }

        public ViajeCiudad UpdateViajeCiudad(int viajeciudadId, ViajeCiudadRequest request)
        {
            var entryOriginal = _context.ViajeCiudades.Include(c => c.Ciudad)
                 .ThenInclude(pr => pr.Provincia)
                 .ThenInclude(pa => pa.Pais)
                         .FirstOrDefault(x => x.ViajeCiudadId == viajeciudadId);
            if (entryOriginal != null)
            {
                entryOriginal.ViajeId = request.ViajeId;
                entryOriginal.CiudadId = request.CiudadId;

                _context.Update(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }
    }
}
