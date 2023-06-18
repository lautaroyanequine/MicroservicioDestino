using Application.Interfaces.ICiudad;
using Application.Request.Ciudad;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class CiudadCommand : ICiudadCommand
    {
        private readonly DestinosContext _context;
        public CiudadCommand(DestinosContext context) { _context = context; }
        public Ciudad InsertCiudad(Ciudad ciudad)
        {
            if (ciudad != null)
            {
                _context.Add(ciudad);
                _context.SaveChanges();
            }
            return ciudad;
        }

        public Ciudad RemoveCiudad(int ciudadId)
        {
            var entryOriginal = _context.Ciudades.Include(c => c.Provincia)
                .ThenInclude(pa => pa.Pais).FirstOrDefault(x => x.CiudadId == ciudadId);
            if (entryOriginal != null)
            {
                _context.Remove(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }

        public Ciudad UpdateCiudad(int ciudadId, CiudadRequest request)
        {
            var entryOriginal = _context.Ciudades.Include(c => c.Provincia)
                .ThenInclude(pa => pa.Pais)
                .FirstOrDefault(x => x.CiudadId == ciudadId);
            if (entryOriginal != null)
            {
                entryOriginal.Nombre = request.Nombre;
                entryOriginal.ProvinciaId = request.ProvinciaId;
                _context.Update(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }
    }
}
