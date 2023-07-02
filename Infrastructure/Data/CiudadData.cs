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
                    Nombre = "Villa Gesel",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 5,
                    Nombre = "Necochea",
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
                    Nombre = "Sierra de la Ventana",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 8,
                    Nombre = "Retiro",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 9,
                    Nombre = "Once",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 10,
                    Nombre = "Ciudad Autonoma de Buenos Aires",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 11,
                    Nombre = "Ezeiza",
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
                    Nombre = "Quilmes",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 14,
                    Nombre = "Avellaneda",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 15,
                    Nombre = "Lomas de Zamora",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 16,
                    Nombre = "San Isidro",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 17,
                    Nombre = "Tigre",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 18,
                    Nombre = "Constitución",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 19,
                    Nombre = "Florecio Varela",
                    ProvinciaId = 1
                },
                new Ciudad
                {
                    CiudadId = 20,
                    Nombre = "Ushuaia",
                    ProvinciaId = 2
                },
                new Ciudad
                {
                    CiudadId = 21,
                    Nombre = "Río Grande",
                    ProvinciaId = 2
                },
                new Ciudad
                {
                    CiudadId = 22,
                    Nombre = "Tolhuin",
                    ProvinciaId = 2
                },
                new Ciudad
                {
                    CiudadId = 23,
                    Nombre = "Córdoba",
                    ProvinciaId = 3
                },
                new Ciudad
                {
                    CiudadId = 24,
                    Nombre = "Villa Carlos Paz",
                    ProvinciaId = 3
                },
                new Ciudad
                {
                    CiudadId = 25,
                    Nombre = "La Falda",
                    ProvinciaId = 3
                },
                new Ciudad
                {
                    CiudadId = 26,
                    Nombre = "Santa Fe",
                    ProvinciaId = 4
                },
                new Ciudad
                {
                    CiudadId = 27,
                    Nombre = "Rosario",
                    ProvinciaId = 4
                },
                new Ciudad
                {
                    CiudadId = 28,
                    Nombre = "Venado Tuerto",
                    ProvinciaId = 4
                },
                new Ciudad
                {
                    CiudadId = 29,
                    Nombre = "Mendoza",
                    ProvinciaId = 5
                },
                new Ciudad
                {
                    CiudadId = 30,
                    Nombre = "San Rafael",
                    ProvinciaId = 5
                },
                new Ciudad
                {
                    CiudadId = 31,
                    Nombre = "Malargüe",
                    ProvinciaId = 5
                },
                new Ciudad
                {
                    CiudadId = 32,
                    Nombre = "Salta",
                    ProvinciaId = 6
                },
                new Ciudad
                {
                    CiudadId = 33,
                    Nombre = "Cafayate",
                    ProvinciaId = 6
                },
                new Ciudad
                {
                    CiudadId = 34,
                    Nombre = "San Antonio de los Cobres",
                    ProvinciaId = 6
                },
                new Ciudad
                {
                    CiudadId = 35,
                    Nombre = "San Salvador de Jujuy",
                    ProvinciaId = 7
                },
                new Ciudad
                {
                    CiudadId = 36,
                    Nombre = "Purmamarca",
                    ProvinciaId = 7
                },
                new Ciudad
                {
                    CiudadId = 37,
                    Nombre = "Tilcara",
                    ProvinciaId = 7
                },

                new Ciudad
                {
                    CiudadId = 38,
                    Nombre = "Puerto Madryn",
                    ProvinciaId = 8
                },
                new Ciudad
                {
                    CiudadId = 39,
                    Nombre = "Trelew",
                    ProvinciaId = 8
                },
                new Ciudad
                {
                    CiudadId = 40,
                    Nombre = "Comodoro Rivadavia",
                    ProvinciaId = 8
                },
                new Ciudad
                {
                    CiudadId = 41,
                    Nombre = "Neuquén",
                    ProvinciaId = 9
                },
                new Ciudad
                {
                    CiudadId = 42,
                    Nombre = "San Martín de los Andes",
                    ProvinciaId = 9
                },
                new Ciudad
                {
                    CiudadId = 43,
                    Nombre = "Villa La Angostura",
                    ProvinciaId = 9
                },
                new Ciudad
                {
                    CiudadId = 44,
                    Nombre = "San Juan",
                    ProvinciaId = 10
                },
                new Ciudad
                {
                    CiudadId = 45,
                    Nombre = "Valle de la Luna",
                    ProvinciaId = 10
                },
                new Ciudad
                {
                    CiudadId = 46,
                    Nombre = "Barreal",
                    ProvinciaId = 10
                },
                new Ciudad
                {
                    CiudadId = 47,
                    Nombre = "San Luis",
                    ProvinciaId = 11
                },
                new Ciudad
                {
                    CiudadId = 48,
                    Nombre = "Merlo",
                    ProvinciaId = 11
                },
                new Ciudad
                {
                    CiudadId = 49,
                    Nombre = "Potrero de los Funes",
                    ProvinciaId = 11
                },
                new Ciudad
                {
                    CiudadId = 50,
                    Nombre = "Santa Rosa",
                    ProvinciaId = 12
                },
                new Ciudad
                {
                    CiudadId = 51,
                    Nombre = "General Pico",
                    ProvinciaId = 12
                },
                new Ciudad
                {
                    CiudadId = 52,
                    Nombre = "Toay",
                    ProvinciaId = 12
                },
                new Ciudad
                {
                    CiudadId = 53,
                    Nombre = "Paraná",
                    ProvinciaId = 13
                },
                new Ciudad
                {
                    CiudadId = 54,
                    Nombre = "Gualeguaychú",
                    ProvinciaId = 13
                },
                new Ciudad
                {
                    CiudadId = 55,
                    Nombre = "Concordia",
                    ProvinciaId = 13
                },
                new Ciudad
                {
                    CiudadId = 56,
                    Nombre = "Corrientes",
                    ProvinciaId = 14
                },
                new Ciudad
                {
                    CiudadId = 57,
                    Nombre = "Mercedes",
                    ProvinciaId = 14
                },
                new Ciudad
                {
                    CiudadId = 58,
                    Nombre = "Goya",
                    ProvinciaId = 14
                },
                new Ciudad
                {
                    CiudadId = 59,
                    Nombre = "Posadas",
                    ProvinciaId = 15
                },
                new Ciudad
                {
                    CiudadId = 60,
                    Nombre = "Iguazú",
                    ProvinciaId = 15
                },
                new Ciudad
                {
                    CiudadId = 61,
                    Nombre = "Puerto Esperanza",
                    ProvinciaId = 15
                },
                new Ciudad
                {
                    CiudadId = 62,
                    Nombre = "Formosa",
                    ProvinciaId = 16
                },
                new Ciudad
                {
                    CiudadId = 63,
                    Nombre = "Clorinda",
                    ProvinciaId = 16
                },
                new Ciudad
                {
                    CiudadId = 64,
                    Nombre = "Laguna Yema",
                    ProvinciaId = 16
                },
                new Ciudad
                {
                    CiudadId = 65,
                    Nombre = "Resistencia",
                    ProvinciaId = 17
                },
                new Ciudad
                {
                    CiudadId = 66,
                    Nombre = "Villa Ángela",
                    ProvinciaId = 17
                },
                new Ciudad
                {
                    CiudadId = 67,
                    Nombre = "Presidencia Roque Sáenz Peña",
                    ProvinciaId = 17
                },
                new Ciudad
                {
                    CiudadId = 68,
                    Nombre = "Santiago del Estero",
                    ProvinciaId = 18
                },
                new Ciudad
                {
                    CiudadId = 69,
                    Nombre = "Termas de Río Hondo",
                    ProvinciaId = 18
                },
                new Ciudad
                {
                    CiudadId = 70,
                    Nombre = "Añatuya",
                    ProvinciaId = 18
                },
                new Ciudad
                {
                    CiudadId = 71,
                    Nombre = "San Miguel de Tucumán",
                    ProvinciaId = 19
                },
                new Ciudad
                {
                    CiudadId = 72,
                    Nombre = "Tafí del Valle",
                    ProvinciaId = 19
                },
                new Ciudad
                {
                    CiudadId = 73,
                    Nombre = "San Javier",
                    ProvinciaId = 19
                },
                new Ciudad
                {
                    CiudadId = 74,
                    Nombre = "San Fernando del Valle de Catamarca",
                    ProvinciaId = 20
                },
                new Ciudad
                {
                    CiudadId = 75,
                    Nombre = "Belén",
                    ProvinciaId = 20
                },
                new Ciudad
                {
                    CiudadId = 76,
                    Nombre = "Fiambalá",
                    ProvinciaId = 20
                },
                new Ciudad
                {
                    CiudadId = 77,
                    Nombre = "La Rioja",
                    ProvinciaId = 21
                },
                new Ciudad
                {
                    CiudadId = 78,
                    Nombre = "Chilecito",
                    ProvinciaId = 21
                },
                new Ciudad
                {
                    CiudadId = 79,
                    Nombre = "Villa Unión",
                    ProvinciaId = 21
                },
                new Ciudad
                {
                    CiudadId = 80,
                    Nombre = "Río Gallegos",
                    ProvinciaId = 22
                },
                new Ciudad
                {
                    CiudadId = 81,
                    Nombre = "El Calafate",
                    ProvinciaId = 22
                },
                new Ciudad
                {
                    CiudadId = 82,
                    Nombre = "Puerto Deseado",
                    ProvinciaId = 22
                },
                new Ciudad
                {
                    CiudadId = 83,
                    Nombre = "Viedma",
                    ProvinciaId = 23
                },
                new Ciudad
                {
                    CiudadId = 84,
                    Nombre = "San Carlos de Bariloche",
                    ProvinciaId = 23
                },
                new Ciudad
                {
                    CiudadId = 85,
                    Nombre = "El Bolsón",
                    ProvinciaId = 23
                },
                new Ciudad
                {
                    CiudadId = 86,
                    Nombre = "Manaus",
                    ProvinciaId = 24
                },
                new Ciudad
                {
                    CiudadId = 87,
                    Nombre = "Belém",
                    ProvinciaId = 24
                },
                new Ciudad
                {
                    CiudadId = 88,
                    Nombre = "Recife",
                    ProvinciaId = 25
                },
                new Ciudad
                {
                    CiudadId = 89,
                    Nombre = "Salvador",
                    ProvinciaId = 25
                },
                new Ciudad
                {
                    CiudadId = 90,
                    Nombre = "Brasília",
                    ProvinciaId = 26
                },
                new Ciudad
                {
                    CiudadId = 91,
                    Nombre = "São Paulo",
                    ProvinciaId = 27
                },
                new Ciudad
                {
                    CiudadId = 92,
                    Nombre = "Rio de Janeiro",
                    ProvinciaId = 27
                },
                new Ciudad
                {
                    CiudadId = 93,
                    Nombre = "Curitiba",
                    ProvinciaId = 28
                },
                new Ciudad
                {
                    CiudadId = 94,
                    Nombre = "Porto Alegre",
                    ProvinciaId = 28
                },
                new Ciudad
                {
                    CiudadId = 95,
                    Nombre = "Montevideo",
                    ProvinciaId = 29
                },

                new Ciudad
                {
                    CiudadId = 96,
                    Nombre = "Canelones",
                    ProvinciaId = 30
                },

                new Ciudad
                {
                    CiudadId = 97,
                    Nombre = "Punta Del Este",
                    ProvinciaId = 31
                },
                new Ciudad
                {
                    CiudadId = 98,
                    Nombre = "Santiago",
                    ProvinciaId = 32
                },
                new Ciudad
                {
                    CiudadId = 99,
                    Nombre = "Valparaíso",
                    ProvinciaId = 32
                },
                new Ciudad
                {
                    CiudadId = 100,
                    Nombre = "Antofagasta",
                    ProvinciaId = 32
                },
                new Ciudad
                {
                    CiudadId = 101,
                    Nombre = "Asunción",
                    ProvinciaId = 35
                },
                new Ciudad
                {
                    CiudadId = 102,
                    Nombre = "Pedro Juan Caballero",
                    ProvinciaId = 36
                },
                new Ciudad
                {
                    CiudadId = 103,
                    Nombre = "Ciudad del Este",
                    ProvinciaId = 37
                },
                new Ciudad
                {
                    CiudadId = 104,
                    Nombre = "Lima",
                    ProvinciaId = 38
                },
                new Ciudad
                {
                    CiudadId = 105,
                    Nombre = "Arequipa",
                    ProvinciaId = 39
                },
                new Ciudad
                {
                    CiudadId = 106,
                    Nombre = "Cusco",
                    ProvinciaId = 40
                },
                new Ciudad
                {
                    CiudadId = 107,
                    Nombre = "Ciudad de México",
                    ProvinciaId = 41
                },
                new Ciudad
                {
                    CiudadId = 108,
                    Nombre = "Guadalajara",
                    ProvinciaId = 42
                },
                new Ciudad
                {
                    CiudadId = 109,
                    Nombre = "Cancún",
                    ProvinciaId = 43
                },
                new Ciudad
                {
                    CiudadId = 110,
                    Nombre = "Playa del Carmen",
                    ProvinciaId = 43
                },
                new Ciudad
                {
                    CiudadId = 111,
                    Nombre = "Tulum",
                    ProvinciaId = 43
                },
                new Ciudad
                {
                    CiudadId = 112,
                    Nombre = "Bogotá",
                    ProvinciaId = 44
                },
                new Ciudad
                {
                    CiudadId = 113,
                    Nombre = "Medellín",
                    ProvinciaId = 45
                },
                new Ciudad
                {
                    CiudadId = 114,
                    Nombre = "Santa Marta",
                    ProvinciaId = 46
                },
                new Ciudad
                {
                    CiudadId = 115,
                    Nombre = "Barranquilla",
                    ProvinciaId = 47
                },
                new Ciudad
                {
                    CiudadId = 116,
                    Nombre = "Los Ángeles",
                    ProvinciaId = 48
                },
                new Ciudad
                {
                    CiudadId = 117,
                    Nombre = "Houston",
                    ProvinciaId = 49
                },
                new Ciudad
                {
                    CiudadId = 118,
                    Nombre = "Miami",
                    ProvinciaId = 50
                },
                new Ciudad
                {
                    CiudadId = 119,
                    Nombre = "Nueva York",
                    ProvinciaId = 51
                },
                new Ciudad
                {
                    CiudadId = 120,
                    Nombre = "Chicago",
                    ProvinciaId = 52
                },
                new Ciudad
                {
                    CiudadId = 121,
                    Nombre = "París",
                    ProvinciaId = 53
                },
                new Ciudad
                {
                    CiudadId = 122,
                    Nombre = "Marsella",
                    ProvinciaId = 54
                },
                new Ciudad
                {
                    CiudadId = 123,
                    Nombre = "Lyon",
                    ProvinciaId = 55
                },
                new Ciudad
                {
                    CiudadId = 124,
                    Nombre = "Milán",
                    ProvinciaId = 56
                },
                new Ciudad
                {
                    CiudadId = 125,
                    Nombre = "Roma",
                    ProvinciaId = 57
                },
                new Ciudad
                {
                    CiudadId = 126,
                    Nombre = "Venecia",
                    ProvinciaId = 58
                },
                new Ciudad
                {
                    CiudadId = 127,
                    Nombre = "Colonia",
                    ProvinciaId = 59
                },
                new Ciudad
                {
                    CiudadId = 128,
                    Nombre = "Múnich",
                    ProvinciaId = 60
                },
                new Ciudad
                {
                    CiudadId = 129,
                    Nombre = "Hanóver",
                    ProvinciaId = 61
                },
                new Ciudad
                {
                    CiudadId = 130,
                    Nombre = "Tokio",
                    ProvinciaId = 62
                },
                new Ciudad
                {
                    CiudadId = 131,
                    Nombre = "Osaka",
                    ProvinciaId = 63
                },
                new Ciudad
                {
                    CiudadId = 132,
                    Nombre = "Sapporo",
                    ProvinciaId = 64
                },
                new Ciudad
                {
                    CiudadId = 133,
                    Nombre = "Pekín",
                    ProvinciaId = 65
                },
                new Ciudad
                {
                    CiudadId = 134,
                    Nombre = "Shanghái",
                    ProvinciaId = 66
                },
                new Ciudad
                {
                    CiudadId = 135,
                    Nombre = "Cantón",
                    ProvinciaId = 67
                },
                new Ciudad
                {
                    CiudadId = 136,
                    Nombre = "Moscú",
                    ProvinciaId = 68
                },
                new Ciudad
                {
                    CiudadId = 137,
                    Nombre = "San Petersburgo",
                    ProvinciaId = 69
                },
                new Ciudad
                {
                    CiudadId = 138,
                    Nombre = "Sochi",
                    ProvinciaId = 70
                },
                new Ciudad
                {
                    CiudadId = 139,
                    Nombre = "Sídney",
                    ProvinciaId = 71
                },
                new Ciudad
                {
                    CiudadId = 140,
                    Nombre = "Melbourne",
                    ProvinciaId = 72
                },
                new Ciudad
                {
                    CiudadId = 141,
                    Nombre = "Brisbane",
                    ProvinciaId = 73
                },
                new Ciudad
                {
                    CiudadId = 142,
                    Nombre = "Toronto",
                    ProvinciaId = 74
                },
                new Ciudad
                {
                    CiudadId = 143,
                    Nombre = "Montreal",
                    ProvinciaId = 75
                },
                new Ciudad
                {
                    CiudadId = 144,
                    Nombre = "Vancouver",
                    ProvinciaId = 76
                },
                new Ciudad
                {
                    CiudadId = 145,
                    Nombre = "Madrid",
                    ProvinciaId = 77
                },
                new Ciudad
                {
                    CiudadId = 146,
                    Nombre = "Barcelona",
                    ProvinciaId = 78
                },
                new Ciudad
                {
                    CiudadId = 147,
                    Nombre = "Sevilla",
                    ProvinciaId = 79
                },
                new Ciudad
                {
                    CiudadId = 148,
                    Nombre = "Londres",
                    ProvinciaId = 80
                },
                new Ciudad
                {
                    CiudadId = 149,
                    Nombre = "York",
                    ProvinciaId = 81
                },
                new Ciudad
                {
                    CiudadId = 150,
                    Nombre = "Cornualles",
                    ProvinciaId = 82
                },
                new Ciudad
                {
                    CiudadId = 151,
                    Nombre = "Lisboa",
                    ProvinciaId = 83
                },
                new Ciudad
                {
                    CiudadId = 152,
                    Nombre = "Oporto",
                    ProvinciaId = 84
                },
                new Ciudad
                {
                    CiudadId = 153,
                    Nombre = "Faro",
                    ProvinciaId = 85,
                }
            );
        }
    }
}
