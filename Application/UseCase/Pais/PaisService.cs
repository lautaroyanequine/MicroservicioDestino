using Application.Exceptions;
using Application.Interfaces;
using Application.Request.Pais;
using Application.Response.Pais;
using Domain.Entities;
using Newtonsoft.Json;

namespace Application.UseCase
{
    public class PaisService : IPaisService
    {
        private readonly IPaisCommand _command;
        private readonly IPaisQuery _query;

        public PaisService(IPaisCommand command, IPaisQuery query)
        {
            _command = command;
            _query = query;
        }

        public async Task<bool> IsValidCountry(string countryName)
        {
            HttpClient client = new HttpClient();
            string url = "https://restcountries.com/v3.1/all";
            HttpResponseMessage response = await client.GetAsync(url);
            bool existe = false;
            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(json);
                var country = countries.FirstOrDefault(c => c.translations.spa.common == countryName);
                if (country != null) { existe = true; }

            }
            if (existe) return true;
            return false;
        }

        public async Task<PaisResponse> CreatePais(PaisRequest request)
        {
            if (!await IsValidCountry(request.Nombre)) throw new IdInvalidoException(); ;

            if (!(_query.GetPais(request.Nombre.ToUpper()) == null)) throw new ElementoYaExisteException();

            var pais = new Pais
            {
                Nombre = request.Nombre,
                Codigo= request.Codigo
            };
            _command.InsertPais(pais);
            return new PaisResponse
            {
                Id = pais.PaisId,
                Nombre = request.Nombre,
                Codigo= pais.Codigo
              
            };

        }

        public PaisResponse GetPaisById(int paisId)
        {
            var pais = _query.GetPais(paisId);
            if (pais != null)
            {
                return new PaisResponse { Id = pais.PaisId, Nombre = pais.Nombre,Codigo=pais.Codigo };
            }
            else throw new ElementoInexistenteException();
        }

        public List<PaisResponse> GetPaisList(string? orden = "ASC", string? nombre = null)
        {
            if (orden.ToUpper() != "ASC" && orden.ToUpper() != "DESC") throw new DatoInvalidoException();

            var paises = _query.GetPaisList(orden,nombre);
            var paisesResponses = new List<PaisResponse>();

            foreach (var pais in paises)
            {
                paisesResponses.Add(new PaisResponse
                {
                    Id = pais.PaisId,
                    Nombre = pais.Nombre,
                    Codigo = pais.Codigo
                });
            }
            return paisesResponses;


        }

        public PaisResponse RemovePais(int paisId)
        {
            var pais = _command.RemovePais(paisId);
            if (pais == null) throw new ElementoInexistenteException();
            return new PaisResponse
            {
                Id = pais.PaisId,
                Nombre = pais.Nombre,
                Codigo = pais.Codigo
                
            };
        }

        public async Task<PaisResponse> UpdatePais(int paisId, PaisRequest request)
        {

            if (!await IsValidCountry(request.Nombre)) throw new IdInvalidoException(); ;

            if (_query.GetPais(request.Nombre.ToUpper()) != null) throw new ElementoYaExisteException();
            var pais = _command.UpdatePais(paisId, request);
            if (pais == null) throw new ElementoInexistenteException();
            return new PaisResponse
            {
                Id = pais.PaisId,
                Nombre = pais.Nombre,
                Codigo = pais.Codigo
                
            };

        }
    }
}
