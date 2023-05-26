using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class CiudadConfiguration
    {
        public  CiudadConfiguration(EntityTypeBuilder<Ciudad> entityBuilder)
        {
            entityBuilder.ToTable("Ciudad");
            entityBuilder.Property(m => m.CiudadId).ValueGeneratedOnAdd();
            entityBuilder.HasKey(e => e.CiudadId);

            entityBuilder.HasMany(m => m.ViajeCiudades)
            .WithOne(cm => cm.Ciudad)
            .HasForeignKey(cm => cm.CiudadId);
        }
    }
}
