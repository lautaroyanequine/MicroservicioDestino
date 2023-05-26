using Application.Interfaces;
using Application.Request.Pais;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class PaisCommand : IPaisCommand
    {
        private readonly DestinosContext _context;
        public PaisCommand(DestinosContext context)
        {
            _context = context;
        }

        public Pais InsertPais(Pais pais)
        {
            if (pais != null)
            {
                _context.Add(pais);
                _context.SaveChanges();
            }
            return pais;
        }

        public Pais RemovePais(int paisId)
        {
            var entryOriginal = _context.Paises.FirstOrDefault(x => x.PaisId == paisId);
            if (entryOriginal != null)
            {
                _context.Remove(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }

        public Pais UpdatePais(int paisId, PaisRequest request)
        {
            var entryOriginal = _context.Paises
              .FirstOrDefault(x => x.PaisId == paisId);
            if (entryOriginal != null)
            {
                entryOriginal.Nombre = request.Nombre;
                _context.Update(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }
    }
}
