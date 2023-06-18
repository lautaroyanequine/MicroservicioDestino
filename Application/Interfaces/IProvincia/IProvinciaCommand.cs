using Application.Request.Provincia;
using Domain.Entities;

namespace Application.Interfaces.IProvincia
{
    public interface IProvinciaCommand
    {
        Provincia InsertProvincia(Provincia provincia);
        Provincia UpdateProvincia(int provinciaId, ProvinciaRequest request);
        Provincia RemoveProvincia(int provinciaId);
    }
}
