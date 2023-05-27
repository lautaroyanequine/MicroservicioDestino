using Application.Exceptions;
using Application.Interfaces;
using System.Net.Http;

namespace Infrastructure.Client
{
    public class ClientViaje: IClientViaje
    {
        private readonly HttpClient _httpClient;

        public ClientViaje()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7192/api/");
        }

        public dynamic ObtenerViaje(int viajeId)
        {
            HttpResponseMessage response = _httpClient.GetAsync($"Viaje/{viajeId}").Result;

            if (response.IsSuccessStatusCode)
            {

                dynamic viaje = response.Content.ReadAsAsync<dynamic>().Result;
                return viaje;
            }
            else
            {
                throw new IdInvalidoException();
            }
        }
    }
}