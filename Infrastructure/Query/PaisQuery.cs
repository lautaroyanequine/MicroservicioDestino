using Application.Interfaces.IPais;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Query
{
    public class PaisQuery : IPaisQuery
    {
        private readonly DestinosContext _context;

        public PaisQuery(DestinosContext context)
        {
            _context = context;
        }

        public Pais GetPais(int paisId)
        {
            return _context.Paises.FirstOrDefault(x => x.PaisId == paisId);
        }

        public Pais GetPais(string nombrePais)
        {
            return _context.Paises.FirstOrDefault(x => x.Nombre == nombrePais);
        }

        public List<Pais> GetPaisList(string? orden = "ASC", string? nombre = null)
        {


            IQueryable<Pais> query = _context.Paises;
            if (!string.IsNullOrEmpty(nombre))
            {
                query = query.Where(p => p.Nombre.StartsWith(nombre));
            }

            if (orden.ToUpper() == "ASC") query = query.OrderBy(p => p.Nombre);
            else if (orden.ToUpper() == "DESC") query = query.OrderByDescending(p => p.Nombre);

            return query.ToList();
        }


    }
}
