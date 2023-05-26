using Application.Request.Escala;
using Application.Response.Escala;

namespace Application.Interfaces
{
    public interface IEscalaService
    {
        EscalaResponse CreateEscala(EscalaRequest request);
        EscalaResponse RemoveEscala(int escalaId);
        EscalaResponse UpdateEscala(int escalaId, EscalaRequest request);
        List<EscalaResponse> GetEscalaList();
        EscalaResponse GetEscalaById(int escalaId);
    }
}
