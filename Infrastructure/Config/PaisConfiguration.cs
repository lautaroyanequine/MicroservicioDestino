using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Config
{
    public class PaisConfiguration : IEntityTypeConfiguration<Pais>
    {
        public void Configure(EntityTypeBuilder<Pais> entityBuilder)
        {
            entityBuilder.ToTable("Pais");
            entityBuilder.Property(m => m.PaisId).ValueGeneratedOnAdd();
            entityBuilder.HasKey(e => e.PaisId);

            entityBuilder.HasMany(m => m.Provincias)
            .WithOne(cm => cm.Pais)
            .HasForeignKey(cm => cm.PaisId)
            .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
