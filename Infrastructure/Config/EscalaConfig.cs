using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class EscalaConfiguration
    {
        public  EscalaConfiguration(EntityTypeBuilder<Escala> entityBuilder)
        {
            entityBuilder.ToTable("Escala");
            entityBuilder.Property(m => m.EscalaId).ValueGeneratedOnAdd();
            entityBuilder.HasKey(e => e.EscalaId);
        }
    }
}
