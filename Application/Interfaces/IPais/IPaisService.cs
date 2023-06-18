using Application.Request.Pais;
using Application.Response.Pais;

namespace Application.Interfaces.IPais
{
    public interface IPaisService
    {
        Task<PaisResponse> CreatePais(PaisRequest request);
        PaisResponse RemovePais(int paisId);
        Task<PaisResponse> UpdatePais(int paisId, PaisRequest request);
        List<PaisResponse> GetPaisList(string? orden = "ASC", string? nombre = null);
        PaisResponse GetPaisById(int paisId);
    }
}
