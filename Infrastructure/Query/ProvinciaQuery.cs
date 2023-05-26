using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class ProvinciaQuery : IProvinciaQuery
    {
        private readonly DestinosContext _context;

        public ProvinciaQuery(DestinosContext context)
        {
            _context = context;
        }

        public Provincia GetProvincia(int provinciaId)
        {
            return _context.Provincias.Include(p => p.Pais).FirstOrDefault(x => x.ProvinciaId == provinciaId);
        }

        public Provincia GetProvincia(string nombreProvincia)
        {
            return _context.Provincias.Include(p => p.Pais).FirstOrDefault(x => x.Nombre == nombreProvincia);
        }

        public List<Provincia> GetProvinciaList(string? orden = "ASC", string? nombre = null, string pais = null)
        {
            IQueryable<Provincia> query = _context.Provincias;
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.StartsWith(nombre));
            }
            if (!string.IsNullOrEmpty(pais))
            {
                query = query.Where(p => p.Pais.Nombre.StartsWith(pais));

            }
            if (orden.ToUpper() == "ASC") query = query.OrderBy(p => p.Nombre);
            else if (orden.ToUpper() == "DESC") query = query.OrderByDescending(p => p.Nombre);

            return query.ToList();
        }
    }
}
