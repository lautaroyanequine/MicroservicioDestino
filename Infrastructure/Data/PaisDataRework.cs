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
                    Nombre = "Perú",
                    Codigo = "PER",
                },

                new Pais
                {
                    PaisId = 6,
                    Nombre = "Colombia",
                    Codigo = "COL",
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
                    Nombre = "Costa Rica",
                    Codigo = "CRI",
                },

                new Pais
                {
                    PaisId = 9,
                    Nombre = "Puerto Rico",
                    Codigo = "PRI",
                }

            );
        }
    }
}
