using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class CiudadQuery : ICiudadQuery
    {
        private readonly DestinosContext _context;

        public CiudadQuery(DestinosContext context) { _context = context; }

        public Ciudad GetCiudad(int ciudadId)
        {
            return _context.Ciudades.Include(p => p.Provincia)
                .ThenInclude(pa => pa.Pais)
                .FirstOrDefault(x => x.CiudadId == ciudadId);
        }

        public Ciudad GetCiudad(string nombreCiudad)
        {
            return _context.Ciudades.Include(p => p.Provincia)
                .ThenInclude(pa => pa.Pais)
                .FirstOrDefault(x => x.Nombre == nombreCiudad);
        }

        public List<Ciudad> GetCiudadList(string? orden = "ASC", string? nombre = null, string? provincia = null, string? pais = null)
        {

            IQueryable<Ciudad> query = _context.Ciudades;
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.StartsWith(nombre));
            }
            if (!string.IsNullOrEmpty(provincia))
            {
                query = query.Where(p => p.Provincia.Nombre.StartsWith(provincia));

            }
            if (!string.IsNullOrEmpty(pais))
            {
                query = query.Where(p => p.Provincia.Pais.Nombre.StartsWith(pais));

            }
            query = query.Include(p => p.Provincia)
                .ThenInclude(pa => pa.Pais);
            if (orden.ToUpper() == "ASC") query = query.OrderBy(p => p.Nombre);
            else if (orden.ToUpper() == "DESC") query = query.OrderByDescending(p => p.Nombre);

            return query.ToList();

          
        }
    }
}
