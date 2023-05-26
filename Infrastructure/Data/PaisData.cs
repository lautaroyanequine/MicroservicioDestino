using Application.Response.Pais;
using Domain.Entities;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Infrastructure.Data
{
    public class PaisData
    {
        public static async Task SeedPaises()
        {

            using var dbContext = new DestinosContext();
            if (!dbContext.Paises.Any())
            {

            


                HttpClient client = new HttpClient();
            string url = "https://restcountries.com/v3.1/all";
            HttpResponseMessage response = await client.GetAsync(url);
                if (response.IsSuccessStatusCode)
                {
                    string json = await response.Content.ReadAsStringAsync();

                    List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(json);
                    List<Pais> pais = new List<Pais>();
                    foreach (var item in countries)
                    {
                        if (item.cioc == null)
                        {
                            pais.Add(new Pais
                            {
                                Nombre = item.translations.spa.common,
                                Codigo = item.cca3
                            });
                        }
                        else


                            pais.Add(new Pais
                            {
                                Nombre = item.translations.spa.common,
                                Codigo = item.cioc
                            });
                    }
                    await dbContext.AddRangeAsync(pais);
                    await dbContext.SaveChangesAsync();


                }
            }




        }

    }
}
