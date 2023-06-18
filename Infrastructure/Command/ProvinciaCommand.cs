using Application.Interfaces.IProvincia;
using Application.Request.Provincia;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Command
{
    public class ProvinciaCommand : IProvinciaCommand
    {
        private readonly DestinosContext _context;
        public ProvinciaCommand(DestinosContext context) { _context = context; }
        public Provincia InsertProvincia(Provincia provincia)
        {
            if (provincia != null)
            {
                _context.Add(provincia);
                _context.SaveChanges();
            }
            return provincia;
        }

        public Provincia RemoveProvincia(int provinciaId)
        {
            var entryOriginal = _context.Provincias.Include(c => c.Pais).FirstOrDefault(x => x.ProvinciaId == provinciaId);
            if (entryOriginal != null)
            {
                _context.Remove(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }

        public Provincia UpdateProvincia(int provinciaId, ProvinciaRequest request)
        {
            var entryOriginal = _context.Provincias.Include(c => c.Pais).FirstOrDefault(x => x.ProvinciaId == provinciaId);
            if (entryOriginal != null)
            {
                entryOriginal.Nombre = request.Nombre;
                entryOriginal.PaisId = request.PaisId;
                _context.Update(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }
    }
}
