using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Data
{
    public class CiudadData : IEntityTypeConfiguration<Ciudad>
    {
        public void Configure(EntityTypeBuilder<Ciudad> entityBuilder)
        {
            entityBuilder.HasData
            (
                new Ciudad
                {
                    CiudadId = 1,
                    Nombre = "La Plata",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 2,
                    Nombre = "Mar del Plata",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 3,
                    Nombre = "Bahía Blanca",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 4,
                    Nombre = "San Nicolás de los Arroyos",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 5,
                    Nombre = "Pergamino",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 6,
                    Nombre = "Tandil",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 7,
                    Nombre = "Junín",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 8,
                    Nombre = "Olavarría",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 9,
                    Nombre = "Azul",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 10,
                    Nombre = "Necochea",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 11,
                    Nombre = "Zárate",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 12,
                    Nombre = "Campana",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 13,
                    Nombre = "Morón",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 14,
                    Nombre = "Quilmes",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 15,
                    Nombre = "Avellaneda",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 16,
                    Nombre = "Lomas de Zamora",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 17,
                    Nombre = "Lanús",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 18,
                    Nombre = "San Isidro",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 19,
                    Nombre = "Tigre",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 20,
                    Nombre = "Vicente López",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 21,
                    Nombre = "Florecio Varela",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 22,
                    Nombre = "Ushuaia",
                    ProvinciaId = 2
                },

                new Ciudad
                {
                    CiudadId = 23,
                    Nombre = "Río Grande",
                    ProvinciaId = 2
                },

                new Ciudad
                {
                    CiudadId = 24,
                    Nombre = "Tolhuin",
                    ProvinciaId = 2
                },

                new Ciudad
                {
                    CiudadId = 25,
                    Nombre = "Córdoba",
                    ProvinciaId = 3
                },

                new Ciudad
                {
                    CiudadId = 26,
                    Nombre = "Villa Carlos Paz",
                    ProvinciaId = 3
                },

                new Ciudad
                {
                    CiudadId = 27,
                    Nombre = "Río Cuarto",
                    ProvinciaId = 3
                },
                new Ciudad
                {
                    CiudadId = 28,
                    Nombre = "Santa Fe",
                    ProvinciaId = 4
                },

                new Ciudad
                {
                    CiudadId = 29,
                    Nombre = "Rosario",
                    ProvinciaId = 4
                },

                new Ciudad
                {
                    CiudadId = 30,
                    Nombre = "Venado Tuerto",
                    ProvinciaId = 4
                },
                new Ciudad
                {
                    CiudadId = 31,
                    Nombre = "Mendoza",
                    ProvinciaId = 5
                },

                new Ciudad
                {
                    CiudadId = 32,
                    Nombre = "San Rafael",
                    ProvinciaId = 5
                },

                new Ciudad
                {
                    CiudadId = 33,
                    Nombre = "Maipú",
                    ProvinciaId = 5
                },
                new Ciudad
                {
                    CiudadId = 34,
                    Nombre = "Salta",
                    ProvinciaId = 6
                },

                new Ciudad
                {
                    CiudadId = 35,
                    Nombre = "Cafayate",
                    ProvinciaId = 6
                },

                new Ciudad
                {
                    CiudadId = 36,
                    Nombre = "San Ramón de la Nueva Orán",
                    ProvinciaId = 6
                },
                new Ciudad
                {
                    CiudadId = 37,
                    Nombre = "San Salvador de Jujuy",
                    ProvinciaId = 7
                },

                new Ciudad
                {
                    CiudadId = 38,
                    Nombre = "Purmamarca",
                    ProvinciaId = 7
                },

                new Ciudad
                {
                    CiudadId = 39,
                    Nombre = "Tilcara",
                    ProvinciaId = 7
                },
                new Ciudad
                {
                    CiudadId = 40,
                    Nombre = "Rawson",
                    ProvinciaId = 8
                },

                new Ciudad
                {
                    CiudadId = 41,
                    Nombre = "Comodoro Rivadavia",
                    ProvinciaId = 8
                },

                new Ciudad
                {
                    CiudadId = 42,
                    Nombre = "Puerto Madryn",
                    ProvinciaId = 8
                },
                new Ciudad
                {
                    CiudadId = 43,
                    Nombre = "Neuquén",
                    ProvinciaId = 9
                },

                new Ciudad
                {
                    CiudadId = 44,
                    Nombre = "San Martín de los Andes",
                    ProvinciaId = 9
                },

                new Ciudad
                {
                    CiudadId = 45,
                    Nombre = "Villa La Angostura",
                    ProvinciaId = 9
                },
                new Ciudad
                {
                    CiudadId = 46,
                    Nombre = "San Juan",
                    ProvinciaId = 10
                },

                new Ciudad
                {
                    CiudadId = 47,
                    Nombre = "Rawson",
                    ProvinciaId = 10
                },

                new Ciudad
                {
                    CiudadId = 48,
                    Nombre = "Pocito",
                    ProvinciaId = 10
                },
                new Ciudad
                {
                    CiudadId = 49,
                    Nombre = "São Paulo",
                    ProvinciaId = 11
                },

                new Ciudad
                {
                    CiudadId = 50,
                    Nombre = "Campinas",
                    ProvinciaId = 11
                },

                new Ciudad
                {
                    CiudadId = 51,
                    Nombre = "Guarulhos",
                    ProvinciaId = 11
                },
                new Ciudad
                {
                    CiudadId = 52,
                    Nombre = "Rio de Janeiro",
                    ProvinciaId = 12
                },

                new Ciudad
                {
                    CiudadId = 53,
                    Nombre = "Niterói",
                    ProvinciaId = 12
                },

                new Ciudad
                {
                    CiudadId = 54,
                    Nombre = "Búzios",
                    ProvinciaId = 12
                },
                new Ciudad
                {
                    CiudadId = 55,
                    Nombre = "Montevideo",
                    ProvinciaId = 21
                },

                new Ciudad
                {
                    CiudadId = 56,
                    Nombre = "Ciudad de la Costa",
                    ProvinciaId = 21
                },

                new Ciudad
                {
                    CiudadId = 57,
                    Nombre = "Pocitos",
                    ProvinciaId = 21
                },
                new Ciudad
                {
                    CiudadId = 58,
                    Nombre = "Colonia del Sacramento",
                    ProvinciaId = 25
                },

                new Ciudad
                {
                    CiudadId = 59,
                    Nombre = "Nueva Helvecia",
                    ProvinciaId = 25
                },

                new Ciudad
                {
                    CiudadId = 60,
                    Nombre = "Carmelo",
                    ProvinciaId = 25
                },
                new Ciudad
                {
                    CiudadId = 61,
                    Nombre = "Santiago",
                    ProvinciaId = 31
                },

                new Ciudad
                {
                    CiudadId = 62,
                    Nombre = "Providencia",
                    ProvinciaId = 31
                },

                new Ciudad
                {
                    CiudadId = 63,
                    Nombre = "Las Condes",
                    ProvinciaId = 31
                },
                new Ciudad
                {
                    CiudadId = 64,
                    Nombre = "Valparaíso",
                    ProvinciaId = 32
                },

                new Ciudad
                {
                    CiudadId = 65,
                    Nombre = "Viña del Mar",
                    ProvinciaId = 32
                },

                new Ciudad
                {
                    CiudadId = 66,
                    Nombre = "Quilpué",
                    ProvinciaId = 32
                },
                new Ciudad
                {
                    CiudadId = 67,
                    Nombre = "Lima",
                    ProvinciaId = 41
                },

                new Ciudad
                {
                    CiudadId = 68,
                    Nombre = "Miraflores",
                    ProvinciaId = 41
                },

                new Ciudad
                {
                    CiudadId = 69,
                    Nombre = "San Isidro",
                    ProvinciaId = 41
                },
                new Ciudad
                {
                    CiudadId = 71,
                    Nombre = "Cusco",
                    ProvinciaId = 43
                },

                new Ciudad
                {
                    CiudadId = 72,
                    Nombre = "Machu Picchu",
                    ProvinciaId = 43
                },

                new Ciudad
                {
                    CiudadId = 73,
                    Nombre = "Ollantaytambo",
                    ProvinciaId = 43
                },
                new Ciudad
                {
                    CiudadId = 74,
                    Nombre = "Cali",
                    ProvinciaId = 53
                },

                new Ciudad
                {
                    CiudadId = 75,
                    Nombre = "Buenaventura",
                    ProvinciaId = 53
                },

                new Ciudad
                {
                    CiudadId = 76,
                    Nombre = "Palmira",
                    ProvinciaId = 53
                },

                new Ciudad
                {
                    CiudadId = 77,
                    Nombre = "Cartagena",
                    ProvinciaId = 56
                },

                new Ciudad
                {
                    CiudadId = 78,
                    Nombre = "Magangué",
                    ProvinciaId = 56
                },

                new Ciudad
                {
                    CiudadId = 79,
                    Nombre = "Sincelejo",
                    ProvinciaId = 56
                },
                new Ciudad
                {
                    CiudadId = 80,
                    Nombre = "Cancún",
                    ProvinciaId = 61
                },

                new Ciudad
                {
                    CiudadId = 81,
                    Nombre = "Playa del Carmen",
                    ProvinciaId = 61
                },

                new Ciudad
                {
                    CiudadId = 82,
                    Nombre = "Cozumel",
                    ProvinciaId = 61
                },
                new Ciudad
                {
                    CiudadId = 83,
                    Nombre = "Ciudad de México",
                    ProvinciaId = 62
                },

                new Ciudad
                {
                    CiudadId = 84,
                    Nombre = "Ecatepec",
                    ProvinciaId = 62
                },

                new Ciudad
                {
                    CiudadId = 85,
                    Nombre = "Naucalpan",
                    ProvinciaId = 62
                }


            );
        }
    }
}
