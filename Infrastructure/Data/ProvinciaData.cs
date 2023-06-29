using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class ProvinciaData : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> entityBuilder)
        {
            entityBuilder.HasData
            (
                new Provincia
                {
                    ProvinciaId = 1,
                    Nombre = "Buenos Aires",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 2,
                    Nombre = "Tierra del Fuego",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 3,
                    Nombre = "Córdoba",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 4,
                    Nombre = "Santa Fe",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 5,
                    Nombre = "Mendoza",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 6,
                    Nombre = "Salta",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 7,
                    Nombre = "Jujuy",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 8,
                    Nombre = "Chubut",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 9,
                    Nombre = "Neuquén",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 10,
                    Nombre = "San Juan",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 11,
                    Nombre = "São Paulo",
                    PaisId = 2
                },

                new Provincia
                {
                    ProvinciaId = 12,
                    Nombre = "Rio de Janeiro",
                    PaisId = 2
                },

                new Provincia
                {
                    ProvinciaId = 21,
                    Nombre = "Montevideo",
                    PaisId = 3
                },

                new Provincia
                {
                    ProvinciaId = 25,
                    Nombre = "Colonia",
                    PaisId = 3
                },

                new Provincia
                {
                    ProvinciaId = 31,
                    Nombre = "Santiago",
                    PaisId = 4
                },

                new Provincia
                {
                    ProvinciaId = 32,
                    Nombre = "Valparaíso",
                    PaisId = 4
                },

                new Provincia
                {
                    ProvinciaId = 41,
                    Nombre = "Lima",
                    PaisId = 5
                },

                new Provincia
                {
                    ProvinciaId = 43,
                    Nombre = "Cusco",
                    PaisId = 5
                },

                
                new Provincia
                {
                    ProvinciaId = 53,
                    Nombre = "Valle del Cauca",
                    PaisId = 6
                },

                new Provincia
                {
                    ProvinciaId = 56,
                    Nombre = "Bolívar",
                    PaisId = 6
                },

                new Provincia
                {
                    ProvinciaId = 61,
                    Nombre = "Cancún",
                    PaisId = 7
                },

                new Provincia
                {
                    ProvinciaId = 62,
                    Nombre = "Ciudad de México",
                    PaisId = 7
                }
            );
        }
    }
}
