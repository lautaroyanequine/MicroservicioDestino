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
                    Codigo = "Arg",
                },

                new Pais
                {
                    PaisId = 2,
                    Nombre = "Brasil",
                    Codigo = "Br",
                },

                new Pais
                {
                    PaisId = 3,
                    Nombre = "Uruguay",
                    Codigo = "Uy",
                }
            );
        }
    }
}
