using Application.Response.Pais;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Newtonsoft.Json;

namespace Infrastructure.Config
{
    public class PaisConfiguration
    {
        public  PaisConfiguration(EntityTypeBuilder<Pais> entityBuilder)
        {
            entityBuilder.ToTable("Pais");
            entityBuilder.Property(m => m.PaisId).ValueGeneratedOnAdd();
            entityBuilder.HasKey(e => e.PaisId);

            entityBuilder.HasMany(m => m.Provincias)
            .WithOne(cm => cm.Pais)
            .HasForeignKey(cm => cm.PaisId)
            .OnDelete(DeleteBehavior.Cascade);


        }
        //public async Task DataPaises(EntityTypeBuilder<Pais> entityTypeBuilder)
        //{
        //    HttpClient client = new HttpClient();
        //    string url = "https://restcountries.com/v3.1/all";
        //    HttpResponseMessage response = await client.GetAsync(url);
        //    if (response.IsSuccessStatusCode)
        //    {
        //        string json = await response.Content.ReadAsStringAsync();

        //        List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(json);

        //        foreach (var item in countries)
        //        {
        //            entityTypeBuilder.HasData(
        //                new Pais
        //                {
        //                    Nombre = item.translations.spa.common,
        //                    Codigo = item.cioc
        //                });
        //        }

        //    }
        //    entityTypeBuilder.HasData(
        //                new Pais
        //                {
        //                    Nombre = "Argentina",
        //                    Codigo ="ARG"
        //                });

        //}





    }
}
