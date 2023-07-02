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
                    Nombre = "San Luis",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 12,
                    Nombre = "La Pampa",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 13,
                    Nombre = "Entre Ríos",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 14,
                    Nombre = "Corrientes",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 15,
                    Nombre = "Misiones",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 16,
                    Nombre = "Formosa",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 17,
                    Nombre = "Chaco",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 18,
                    Nombre = "Santiago del Estero",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 19,
                    Nombre = "Tucumán",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 20,
                    Nombre = "Catamarca",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 21,
                    Nombre = "La Rioja",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 22,
                    Nombre = "Santa Cruz",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 23,
                    Nombre = "Río Negro",
                    PaisId = 1
                },

                new Provincia
                {
                    ProvinciaId = 24,
                    Nombre = "Norte",
                    PaisId = 2
                },
                new Provincia
                {
                    ProvinciaId = 25,
                    Nombre = "Nordeste",
                    PaisId = 2
                },
                new Provincia
                {
                    ProvinciaId = 26,
                    Nombre = "Centro-Oeste",
                    PaisId = 2
                },
                new Provincia
                {
                    ProvinciaId = 27,
                    Nombre = "Sudeste",
                    PaisId = 2
                },
                new Provincia
                {
                    ProvinciaId = 28,
                    Nombre = "Sul",
                    PaisId = 2
                },

                new Provincia
                {
                    ProvinciaId = 29,
                    Nombre = "Montevideo",
                    PaisId = 3
                },

                new Provincia
                {
                    ProvinciaId = 30,
                    Nombre = "Canelones",
                    PaisId = 3
                },

                new Provincia
                {
                    ProvinciaId = 31,
                    Nombre = "Maldonado",
                    PaisId = 3
                },

                new Provincia
                {
                    ProvinciaId = 32,
                    Nombre = "Metropolitana",
                    PaisId = 4
                },

                new Provincia
                {
                    ProvinciaId = 33,
                    Nombre = "Valparaíso",
                    PaisId = 4
                },

                new Provincia
                {
                    ProvinciaId = 34,
                    Nombre = "Antofagasta",
                    PaisId = 4
                },

                new Provincia
                {
                    ProvinciaId = 35,
                    Nombre = "Asunción",
                    PaisId = 5
                },

                new Provincia
                {
                    ProvinciaId = 36,
                    Nombre = "Amambay",
                    PaisId = 5
                },

                new Provincia
                {
                    ProvinciaId = 37,
                    Nombre = "Alto Paraná",
                    PaisId = 5
                },

                new Provincia
                {
                    ProvinciaId = 38,
                    Nombre = "Lima",
                    PaisId = 6
                },

                new Provincia
                {
                    ProvinciaId = 39,
                    Nombre = "Arequipa",
                    PaisId = 6
                },

                new Provincia
                {
                    ProvinciaId = 40,
                    Nombre = "Cusco",
                    PaisId = 6
                },

                new Provincia
                {
                    ProvinciaId = 41,
                    Nombre = "Ciudad de México",
                    PaisId = 7
                },

                new Provincia
                {
                    ProvinciaId = 42,
                    Nombre = "Jalisco",
                    PaisId = 7
                },

                new Provincia
                {
                    ProvinciaId = 43,
                    Nombre = "Quintana Roo",
                    PaisId = 7
                },

                new Provincia
                {
                    ProvinciaId = 44,
                    Nombre = "Bogotá",
                    PaisId = 8
                },

                new Provincia
                {
                    ProvinciaId = 45,
                    Nombre = "Antioquia",
                    PaisId = 8
                },

                new Provincia
                {
                    ProvinciaId = 46,
                    Nombre = "Magdalena",
                    PaisId = 8
                },

                new Provincia
                {
                    ProvinciaId = 47,
                    Nombre = "Atlántico",
                    PaisId = 8
                },
                new Provincia
                {
                    ProvinciaId = 48,
                    Nombre = "California",
                    PaisId = 9
                },

                new Provincia
                {
                    ProvinciaId = 49,
                    Nombre = "Texas",
                    PaisId = 9
                },

                new Provincia
                {
                    ProvinciaId = 50,
                    Nombre = "Florida",
                    PaisId = 9
                },

                new Provincia
                {
                    ProvinciaId = 51,
                    Nombre = "Nueva York",
                    PaisId = 9
                },

                new Provincia
                {
                    ProvinciaId = 52,
                    Nombre = "Illinois",
                    PaisId = 9
                },
                new Provincia
                {
                    ProvinciaId = 53,
                    Nombre = "Isla de Francia",
                    PaisId = 10
                },

                new Provincia
                {
                    ProvinciaId = 54,
                    Nombre = "Provenza-Alpes-Costa Azul",
                    PaisId = 10
                },

                new Provincia
                {
                    ProvinciaId = 55,
                    Nombre = "Ródano-Alpes",
                    PaisId = 10
                },
                new Provincia
                {
                    ProvinciaId = 56,
                    Nombre = "Lombardía",
                    PaisId = 11
                },

                new Provincia
                {
                    ProvinciaId = 57,
                    Nombre = "Lacio",
                    PaisId = 11
                },

                new Provincia
                {
                    ProvinciaId = 58,
                    Nombre = "Véneto",
                    PaisId = 11
                },
                new Provincia
                {
                    ProvinciaId = 59,
                    Nombre = "Renania del Norte-Westfalia",
                    PaisId = 12
                },

                new Provincia
                {
                    ProvinciaId = 60,
                    Nombre = "Baviera",
                    PaisId = 12
                },

                new Provincia
                {
                    ProvinciaId = 61,
                    Nombre = "Baja Sajonia",
                    PaisId = 12
                },

                new Provincia
                {
                    ProvinciaId = 62,
                    Nombre = "Tokio",
                    PaisId = 13
                },

                new Provincia
                {
                    ProvinciaId = 63,
                    Nombre = "Osaka",
                    PaisId = 13
                },

                new Provincia
                {
                    ProvinciaId = 64,
                    Nombre = "Hokkaido",
                    PaisId = 13
                },

                new Provincia
                {
                    ProvinciaId = 65,
                    Nombre = "Pekín",
                    PaisId = 14
                },

                new Provincia
                {
                    ProvinciaId = 66,
                    Nombre = "Shanghái",
                    PaisId = 14
                },

                new Provincia
                {
                    ProvinciaId = 67,
                    Nombre = "Guangdong",
                    PaisId = 14
                },

                new Provincia
                {
                    ProvinciaId = 68,
                    Nombre = "Moscú",
                    PaisId = 15
                },

                new Provincia
                {
                    ProvinciaId = 69,
                    Nombre = "San Petersburgo",
                    PaisId = 15
                },

                new Provincia
                {
                    ProvinciaId = 70,
                    Nombre = "Krasnodar",
                    PaisId = 15
                },

                new Provincia
                {
                    ProvinciaId = 71,
                    Nombre = "Nueva Gales del Sur",
                    PaisId = 16
                },

                new Provincia
                {
                    ProvinciaId = 72,
                    Nombre = "Victoria",
                    PaisId = 16
                },

                new Provincia
                {
                    ProvinciaId = 73,
                    Nombre = "Queensland",
                    PaisId = 16
                },

                new Provincia
                {
                    ProvinciaId = 74,
                    Nombre = "Ontario",
                    PaisId = 17
                },

                new Provincia
                {
                    ProvinciaId = 75,
                    Nombre = "Quebec",
                    PaisId = 17
                },

                new Provincia
                {
                    ProvinciaId = 76,
                    Nombre = "Columbia Británica",
                    PaisId = 17
                },

                new Provincia
                {
                    ProvinciaId = 77,
                    Nombre = "Madrid",
                    PaisId = 18
                },

                new Provincia
                {
                    ProvinciaId = 78,
                    Nombre = "Cataluña",
                    PaisId = 18
                },

                new Provincia
                {
                    ProvinciaId = 79,
                    Nombre = "Andalucía",
                    PaisId = 18
                },
                new Provincia
                {
                    ProvinciaId = 80,
                    Nombre = "Londres",
                    PaisId = 19
                },

                new Provincia
                {
                    ProvinciaId = 81,
                    Nombre = "Yorkshire",
                    PaisId = 19
                },

                new Provincia
                {
                    ProvinciaId = 82,
                    Nombre = "Cornualles",
                    PaisId = 19
                },
                new Provincia
                {
                    ProvinciaId = 83,
                    Nombre = "Lisboa",
                    PaisId = 20
                },

                new Provincia
                {
                    ProvinciaId = 84,
                    Nombre = "Oporto",
                    PaisId = 20
                },

                new Provincia
                {
                    ProvinciaId = 85,
                    Nombre = "Algarve",
                    PaisId = 20
                }
            );
        }
    }
}
