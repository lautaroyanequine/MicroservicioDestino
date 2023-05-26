using Application.Interfaces;
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

        public List<ViajeCiudad> GetViajeCiudadList()
        {
            return _context.ViajeCiudades.Include(vc => vc.Ciudad)
                 .ThenInclude(pr => pr.Provincia)
                 .ThenInclude(pa => pa.Pais)
        .OrderBy(x => x.ViajeCiudadId).ToList();
        }
    }
}
