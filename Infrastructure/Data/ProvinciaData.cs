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
                    PaisId = 1,
                },

                new Provincia
                {
                    ProvinciaId = 2,
                    Nombre = "Tierra del Fuego",
                    PaisId = 1,
                },

                new Provincia
                {
                    ProvinciaId = 3,
                    Nombre = "Bahía",
                    PaisId = 2,
                }
            );
        }
    }
}
