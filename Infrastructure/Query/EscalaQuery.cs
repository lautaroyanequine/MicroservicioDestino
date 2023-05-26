using Application.Interfaces;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Query
{
    public class EscalaQuery : IEscalaQuery
    {
        private readonly DestinosContext _context;
        public EscalaQuery(DestinosContext context) { _context = context; }
        public Escala GetEscala(string nombreParada)
        {
            return _context.Escalas.Include(p => p.Ciudad)
                .ThenInclude(p => p.Provincia)
                .ThenInclude(pa => pa.Pais).
                FirstOrDefault(x => x.NombreParada==nombreParada);
        }

        public List<Escala> GetEscalaList()
        {
            return _context.Escalas.Include(p => p.Ciudad)
                .ThenInclude(pr => pr.Provincia)
                .ThenInclude(pa => pa.Pais)
                . OrderBy(x => x.CiudadId).ToList();
        }

        public Escala GetEscala(int escalaId)
        {
            return _context.Escalas.Include(p => p.Ciudad)
                .ThenInclude(p => p.Provincia)
                .ThenInclude(pa => pa.Pais)
                .FirstOrDefault(x => x.EscalaId == escalaId);
        }
    }
}
