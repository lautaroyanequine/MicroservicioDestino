using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class PaisDataRework : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> entityBuilder)
        {
            entityBuilder.HasData
            (
                new Pais
                {
                    PaisId = 1,
                    Nombre = "Argentina",
                    Codigo = "ARG",
                },

                new Pais
                {
                    PaisId = 2,
                    Nombre = "Brasil",
                    Codigo = "BRA",
                },

                new Pais
                {
                    PaisId = 3,
                    Nombre = "Uruguay",
                    Codigo = "URY",
                },
                new Pais
                {
                    PaisId = 4,
                    Nombre = "Chile",
                    Codigo = "CHL",
                },

                new Pais
                {
                    PaisId = 5,
                    Nombre = "Paraguay",
                    Codigo = "PAR",
                },

                new Pais
                {
                    PaisId = 6,
                    Nombre = "Perú",
                    Codigo = "PER",
                },

                new Pais
                {
                    PaisId = 7,
                    Nombre = "México",
                    Codigo = "MEX",
                },
                 new Pais
                 {
                     PaisId = 8,
                     Nombre = "Colombia",
                     Codigo = "COL",
                 },

                new Pais
                {
                    PaisId = 9,
                    Nombre = "Estados Unidos",
                    Codigo = "EEUU",
                },

                new Pais
                {
                    PaisId = 10,
                    Nombre = "Francia",
                    Codigo = "FRA"
                },

                new Pais
                {
                    PaisId = 11,
                    Nombre = "Italia",
                    Codigo = "ITA"
                },

                new Pais
                {
                    PaisId = 12,
                    Nombre = "Alemania",
                    Codigo = "DEU"
                },

                new Pais
                {
                    PaisId = 13,
                    Nombre = "Japón",
                    Codigo = "JPN"
                },

                new Pais
                {
                    PaisId = 14,
                    Nombre = "China",
                    Codigo = "CHN"
                },

                new Pais
                {
                    PaisId = 15,
                    Nombre = "Rusia",
                    Codigo = "RUS"
                },

                new Pais
                {
                    PaisId = 16,
                    Nombre = "Australia",
                    Codigo = "AUS"
                },

                new Pais
                {
                    PaisId = 17,
                    Nombre = "Canadá",
                    Codigo = "CAN"
                },

                new Pais
                {
                    PaisId = 18,
                    Nombre = "España",
                    Codigo = "ESP"
                },

                new Pais
                {
                    PaisId = 19,
                    Nombre = "Inglaterra",
                    Codigo = "GBR"
                },

                new Pais
                {
                    PaisId = 20,
                    Nombre = "Portugal",
                    Codigo = "PRT"
                }
            );
        }
    }
}
