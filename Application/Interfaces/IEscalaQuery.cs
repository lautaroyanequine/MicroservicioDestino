using Domain.Entities;

namespace Application.Interfaces
{
    public interface IEscalaQuery
    {
        List<Escala> GetEscalaList();
        Escala GetEscala(int escalaId);
        Escala GetEscala(string nombreParada);
    }
}
