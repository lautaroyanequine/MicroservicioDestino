using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class ProvinciaConfiguration : IEntityTypeConfiguration<Provincia>
    {
        public void Configure(EntityTypeBuilder<Provincia> entityBuilder)
        {
            entityBuilder.ToTable("Provincia");
            entityBuilder.Property(m => m.ProvinciaId).ValueGeneratedOnAdd();
            entityBuilder.HasKey(e => e.ProvinciaId);

            entityBuilder.HasMany(m => m.Ciudades)
            .WithOne(cm => cm.Provincia)
            .HasForeignKey(cm => cm.ProvinciaId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
