using Application.Request.Provincia;
using Application.Response.Provincia;

namespace Application.Interfaces.IProvincia
{
    public interface IProvinciaService
    {
        ProvinciaResponse CreateProvincia(ProvinciaRequest request);
        ProvinciaResponse RemoveProvincia(int provinciaId);
        ProvinciaResponse UpdateProvincia(int provinciaId, ProvinciaRequest request);
        List<ProvinciaResponse> GetProvinciaList(string? orden = "ASC", string? nombre = null, string pais = null);
        ProvinciaResponse GetProvinciaById(int provinciaId);
    }
}
