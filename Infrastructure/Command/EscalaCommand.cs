using Application.Interfaces;
using Application.Request.Escala;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System.Globalization;

namespace Infrastructure.Command
{
    public class EscalaCommand : IEscalaCommand
    {
        private readonly DestinosContext _context;

        public EscalaCommand(DestinosContext context)  {  _context = context;   }

        public Escala InsertEscala(Escala escala)
        {
            if (escala != null)
            {
                _context.Add(escala);
                _context.SaveChanges();
            }
            return escala;
        }

        public Escala RemoveEscala(int escalaId)
        {
            var entryOriginal = _context.Escalas.Include(c => c.Ciudad)
                .ThenInclude(pr => pr.Provincia)
                .ThenInclude(pa => pa.Pais)
                .FirstOrDefault(x => x.EscalaId == escalaId);
            if (entryOriginal != null)
            {
                _context.Remove(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }

        public Escala UpdateEscala(int escalaId, EscalaRequest request, DateTime horaLlegada, DateTime horaSalida)
        {
        
              var entryOriginal = _context.Escalas.Include(c => c.Ciudad).ThenInclude(pr => pr.Provincia)
                .ThenInclude(pa => pa.Pais).FirstOrDefault(x => x.EscalaId == escalaId);
            if (entryOriginal != null)
            {
                entryOriginal.NombreParada = request.NombreParada;
                entryOriginal.HoraLlegada = horaLlegada;
                entryOriginal.HoraSalida = horaSalida;
                entryOriginal.ViajeId= request.ViajeId;
                entryOriginal.CiudadId = request.CiudadId;
                _context.Update(entryOriginal);
                _context.SaveChanges();
            }
            return entryOriginal;
        }
    }
}
