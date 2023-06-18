using Application.Interfaces.IViajeCiudad;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class ViajeCiudadQuery : IViajeCiudadQuery
    {
        private readonly DestinosContext _context;
        public ViajeCiudadQuery(DestinosContext context) { _context = context; }
        public ViajeCiudad GetViajeCiudad(int viajeCiudadId)
        {
            return _context.ViajeCiudades.Include(vc => vc.Ciudad)
                 .ThenInclude(pr => pr.Provincia)
                 .ThenInclude(pa => pa.Pais)
                 .FirstOrDefault(x => x.ViajeCiudadId == viajeCiudadId);
        }

        public List<ViajeCiudad> GetViajeCiudadList(int? viajeId, string? localizacion)
        {
            var ViajeCiudades = _context.ViajeCiudades.Include(vc => vc.Ciudad)
                .ThenInclude(pr => pr.Provincia)
                .ThenInclude(pa => pa.Pais)
                .OrderBy(x => x.ViajeCiudadId)
                .ToList();

            if (viajeId.HasValue)
            {
                ViajeCiudades = ViajeCiudades.Where(vc => vc.ViajeId == viajeId).ToList();
            }

            if (!string.IsNullOrEmpty(localizacion))
            {
                ViajeCiudades = ViajeCiudades.Where(vc => vc.Ciudad.Nombre.ToLower().Contains(localizacion.ToLower())
                || vc.Ciudad.Provincia.Nombre.ToLower().Contains(localizacion.ToLower())
                || vc.Ciudad.Provincia.Pais.Nombre.ToLower().Contains(localizacion.ToLower())).ToList();
            }


            return ViajeCiudades;
        }
    }
}
