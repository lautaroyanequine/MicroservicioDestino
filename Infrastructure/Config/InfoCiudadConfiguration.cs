using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Config
{
    public class InfoCiudadConfiguration : IEntityTypeConfiguration<InfoCiudad>
    {
        public void Configure(EntityTypeBuilder<InfoCiudad> entityBuilder)
        {
            entityBuilder.ToTable("InfoCiudad");
            entityBuilder.HasKey(inf => inf.InfoCiudadId);

            entityBuilder.HasOne(inf => inf.Ciudad)
                .WithOne(c => c.infoCiudad)
                .HasForeignKey<InfoCiudad>(inf => inf.CiudadId);
        }
    }
}
