using Application.Interfaces.IInfoCiudad;
using Domain.Entities;
using Infrastructure.Persistence;

namespace Infrastructure.Command
{
    public class InfoCiudadCommand : IInfoCiudadCommand
    {
        private readonly DestinosContext _context;

        public InfoCiudadCommand(DestinosContext context)
        {
            _context = context;
        }

        public InfoCiudad CreateInfoCiudad(InfoCiudad infoCiudad)
        {
            _context.Add(infoCiudad);
            _context.SaveChanges();
            return infoCiudad;
        }

        public InfoCiudad DeleteInfoCiudad(int infoCiudadId)
        {
            var infoCiudad = _context.infoCiudades.FirstOrDefault(ic => ic.InfoCiudadId == infoCiudadId);

            if (infoCiudad != null)
            {
                _context.Remove(infoCiudad);
                _context.SaveChanges();
                return infoCiudad;
            }

            return null;
        }

        public InfoCiudad UpdateInfoCiudad(int infoCiudadId, InfoCiudad infoCiudad)
        {
            var infoCiudadFound = _context.infoCiudades.FirstOrDefault(ic => ic.InfoCiudadId == infoCiudadId);

            if (infoCiudadFound != null)
            {
                infoCiudadFound.Descripcion = infoCiudad.Descripcion;
                infoCiudadFound.ImagenUrl = infoCiudad.ImagenUrl;
                _context.Update(infoCiudadFound);
                _context.SaveChanges();
                return infoCiudadFound;
            }

            return null;
        }
    }
}
