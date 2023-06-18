using Application.Interfaces.IInfoCiudad;
using Domain.Entities;
using Infrastructure.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Query
{
    public class InfoCiudadQuery : IInfoCiudadQuery
    {
        private readonly DestinosContext _context;

        public InfoCiudadQuery(DestinosContext context)
        {
            _context = context;
        }

        
        public List<InfoCiudad> GetAll()
        {
            return _context.infoCiudades.ToList();
        }

        public InfoCiudad GetByCiudad(int CiudadId)
        {
            var infoCiudad = _context.infoCiudades.FirstOrDefault(ic => ic.CiudadId == CiudadId);
            if (infoCiudad == null) { return null; };
            return infoCiudad;
        }

        public InfoCiudad GetById(int InfoCiudadId)
        {
            var infoCiudad = _context.infoCiudades.FirstOrDefault(ic => ic.InfoCiudadId ==  InfoCiudadId);
            if (infoCiudad == null) { return null; };
            return infoCiudad;
        }
    }
}
