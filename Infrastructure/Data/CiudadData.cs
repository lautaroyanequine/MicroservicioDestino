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
                    Nombre = "Varela",
                    ProvinciaId = 1
                }

            );
        }
    }
}
