using Application.Request.Escala;
using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEscalaCommand
    {
        Escala InsertEscala(Escala escala);
        Escala UpdateEscala(int escalaId, EscalaRequest request, DateTime horaLlegada, DateTime horaSalida);
        Escala RemoveEscala(int escalaId);
    }
}
