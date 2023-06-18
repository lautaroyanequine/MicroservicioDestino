using Application.Request.Pais;
using Domain.Entities;

namespace Application.Interfaces.IPais
{
    public interface IPaisCommand
    {
        Pais InsertPais(Pais pais);
        Pais UpdatePais(int paisId, PaisRequest request);
        Pais RemovePais(int paisId);
    }
}
